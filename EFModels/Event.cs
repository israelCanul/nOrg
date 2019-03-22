using System;

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


        public int EventTypeId { get; set; }
        public EventType EventType_Navigation { get; set; }
    }
}
