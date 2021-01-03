using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Event;
using Application.Enums.Event;
using Application.Interfaces.Repositories;
using MediatR;
using AutoMapper;

namespace Application.Features.Event.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<EventResponse>
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public EventType EventType { get; set; } = EventType.Generic;

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResponse>
        {
            private readonly IEventRepository eventRepository;
            private readonly IMapper mapper;

            public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
            {
                this.eventRepository = eventRepository;
                this.mapper = mapper;
            }

            public async Task<EventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<Domain.Entities.Event>(request);
                await eventRepository.AddAsync(entity);

                return mapper.Map<EventResponse>(entity);
            }
        }
    }
}