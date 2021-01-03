using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Event : AuditableBaseEntity
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public EventType EventType { get; set; }
    }
}
