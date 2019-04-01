using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNari
{
    class PersonWithEventOnly
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string status { get; set; }

        public ICollection<EventWithoutEventType> Event { get; set; }
    }
    class EventWithoutEventType {
        public int EventId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public DateTime eventDate { get; set; }
        public string eventStatus { get; set; }
    }
}
