using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums.Event;

namespace Application.DTOs.Event
{
    public class EventResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public EventType EventType { get; set; } = EventType.Generic;
    }
}
