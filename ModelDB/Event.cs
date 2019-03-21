using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace narilearsi.ModelDB
{
    public class Event
    {
        public Event() {
        }
        public int EventID { get; set; }
        public int eventID { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public DateTime eventDate { get; set; }
        public string eventStatus { get; set; }
    }
}
