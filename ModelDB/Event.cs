using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace narilearsi.ModelDB
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public DateTime eventDate { get; set; }
        public string eventStatus { get; set; }


        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
