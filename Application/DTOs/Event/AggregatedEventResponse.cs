using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Event
{
    public class AggregatedEventResponse
    {
        public string Date { get; set; }
        public IEnumerable<string> Events { get; set; }
    }
}
