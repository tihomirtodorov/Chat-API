using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Event;
using Application.Enums.Event;
using Application.Features.Event.Commands.CreateEvent;
using Application.Features.Event.Queries.GetAllEventsBy;
using ChatAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatAPI.Controllers
{
    [AllowAnonymous]
    public class EventController : BaseApiController
    {
        [HttpPost]
        [SwaggerResponse(200, "Successfully created an event", typeof(EventResponse))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> CreateAsync(CreateEventCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerResponse(200, "Successfully retrieved all events", typeof(IEnumerable<AggregatedEventResponse>))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetAllAsync(AggregateBy aggregateBy)
        {
            var response = await Mediator.Send(new GetAllEventsByQuery() { AggregateBy = aggregateBy });
            return Ok(response);
        }
    }
}
