using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace narilearsi.ModelDB
{
    public class EventType
    {
        [Key]
        public int EventTypeID { get; set; }
        public string etName { get; set; }
        public string etDescription { get; set; }

        public virtual ICollection<Event> events { get; set; }
    }
}