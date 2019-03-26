using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace narilearsi.ModelDB
{
    public class Event
    {
        public Event() {
            EventoEventTypeId = new EventType();
        }
        [Key]
        public int EventId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public DateTime eventDate { get; set; }
        public string eventStatus { get; set; }       

        public EventType EventoEventTypeId { get; set; }
        public ICollection<PhotoPackage> photoPackage { get; set; }
    }
}
