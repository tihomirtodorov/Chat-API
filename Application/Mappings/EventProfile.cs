using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Event;
using Application.Features.Event.Commands.CreateEvent;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventCommand, Event>();

            CreateMap<Event, EventResponse>();
        }
    }
}
