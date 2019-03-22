using System;
using System.Collections.Generic;

namespace narilearsi.EFModels
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int EventType { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventStatus { get; set; }

        public virtual EventType EventTypeNavigation { get; set; }
    }
}
