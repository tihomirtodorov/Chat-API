using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Event;
using Application.Enums.Event;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using MoreLinq;
using EventType = Domain.Enums.EventType;
namespace Application.Features.Event.Queries.GetAllEventsBy
{
    public class GetAllEventsByQuery : IRequest<IEnumerable<AggregatedEventResponse>>
    {
        public AggregateBy AggregateBy { get; set; }

        public class GetAllEventsByHandler : IRequestHandler<GetAllEventsByQuery, IEnumerable<AggregatedEventResponse>>
        {
            private readonly IEventRepository eventRepository;
            private readonly IMapper mapper;

            public GetAllEventsByHandler(IEventRepository eventRepository, IMapper mapper)
            {
                this.eventRepository = eventRepository;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<AggregatedEventResponse>> Handle(GetAllEventsByQuery query, CancellationToken cancellationToken)
            {
                var entities = await eventRepository.GetAllOrderedDesc();

                switch (query.AggregateBy)
                {
                    case AggregateBy.Hour:
                        return GetEventsPerHour(entities);
                    case AggregateBy.Minute:
                        return GetEventsPerMinute(entities);
                    default:
                        return GetEventsPerHour(entities);
                }
            }

            private IEnumerable<AggregatedEventResponse> GetEventsPerMinute(IEnumerable<Domain.Entities.Event> entities)
            {
                var byMinute = entities.GroupBy(x => new
                    { x.CreatedOn.Year, x.CreatedOn.Month, x.CreatedOn.Day, x.CreatedOn.Hour, x.CreatedOn.Minute });

                var records = byMinute.Select(x => new AggregatedEventResponse()
                {
                    Date = $"{GetHourWithMinutePeriod(x.Key.Hour, x.Key.Minute)}",
                    Events = x.ToList().Select(x => x.Message)
                });

                return records;
            }

            private IEnumerable<AggregatedEventResponse> GetEventsPerHour(IEnumerable<Domain.Entities.Event> entities)
            {
                var byHour = entities
                    .GroupBy(x => new { x.CreatedOn.Year, x.CreatedOn.Month, x.CreatedOn.Day, x.CreatedOn.Hour });

                return byHour.Select(x => new AggregatedEventResponse()
                {
                    Date = $"{GetHourPeriod(x.Key.Hour)}",
                    Events = GetHourStatsForEvents(x)
                });
            }

            private IEnumerable<string> GetHourStatsForEvents(IEnumerable<Domain.Entities.Event> entities)
            {
                var joinedCount = entities.Count(x => x.EventType == EventType.Enter);
                var joinedMessage = $"{joinedCount} {GetPluralOfPerson(joinedCount)} entered";

                var leftCount = entities.Count(x => x.EventType == EventType.Leave);
                var leftMessage = $"{leftCount} left";

                var highFivedEntities = entities.Where(x => x.EventType == EventType.HighFive);
                var highFivesSenderCount = highFivedEntities.DistinctBy(x => x.Sender).Count();
                var highFivesReceiverCount = highFivedEntities.DistinctBy(x => x.Receiver).Count();

                var highFivesMessage = $"{highFivesSenderCount} {GetPluralOfPerson(highFivesSenderCount)} high-fived {highFivesReceiverCount} other {GetPluralOfPerson(highFivesReceiverCount)}";

                var commentsCount = entities.Count(x => x.EventType == EventType.Comment);
                var commentsMessage = $"{commentsCount} comments";

                return new[] { joinedMessage, leftMessage, highFivesMessage, commentsMessage };
            }

            private string GetPluralOfPerson(int count)
            {
                return count == 1 ? "person" : "people";
            }

            private string GetHourPeriod(int hour)
            {
                if (hour > 12)
                {
                    return $"{hour - 12}pm";
                }
                else if (hour == 12)
                {
                    return $"{hour}pm";
                }
                else
                {
                    return $"{hour}am";
                }
            }

            private string GetHourWithMinutePeriod(int hour, int minute)
            {
                if (hour > 12)
                {
                    return $"{hour - 12}:{minute}pm";
                }
                else if (hour == 12)
                {
                    return $"{hour}:{minute}pm";
                }
                else
                {
                    return $"{hour}:{minute}am";
                }
            }
        }

    }
}
