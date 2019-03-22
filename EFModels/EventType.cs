using System;
using System.Collections.Generic;

namespace narilearsi.EFModels
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string EtName { get; set; }
        public string EtDescription { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
