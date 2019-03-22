using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace narilearsi.ModelDB
{
    public class EventType
    {
        //public EventType() {
        //    this.events = new HashSet<Event>();
        //}
        [Key]
        public int EventTypeId { get; set; }
        public string etName { get; set; }
        public string etDescription { get; set; }
        //public virtual ICollection<Event> Event { get; set; } = new HashSet<Event>();
    }
}