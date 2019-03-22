using System;
using System.Collections.Generic;

namespace narilearsi.EFModels
{
    public partial class EventType
    {
        public int EventTypeId { get; set; }
        public string EtName { get; set; }
        public string EtDescription { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
