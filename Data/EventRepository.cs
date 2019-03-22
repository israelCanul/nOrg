using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class EventRepository : IEventRepository
    {
        private DBContext _context;
        public EventRepository(DBContext context)
        {
            _context = context;
        }

        public Event GetEvent(int eventID)
        {
            return _context.Event.Where(c => c.EventId == eventID).SingleOrDefault();
        }

        public IEnumerable<Event> GetEvents()
        {
            var res = _context.Event.Include(c => c.EventType).ToList();
            return res;
        }
        public Event SetEvent()
        {
            var res = new Event
            {
                eventName = "nuevo",
                eventDescription = "ejemplo de nuevo",
                eventDate = new DateTime(),
                eventStatus = "Pending",
                EventType = new EventType
                {
                    etName = "EJEMPLO",
                    etDescription = "Esta es su descripcion"
                }
            };
            _context.Add(res);
            _context.SaveChanges();
            return res;
        }
    }
}
