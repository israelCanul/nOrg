using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private DBContext _context;
        public EventTypeRepository(DBContext context)
        {
            _context = context;
        }

        public EventType GetEvent(int eventTypeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventType> GetEventTypes()
        {
            var EventTypes = _context.EventType.Include(c => c.events).ToList();
            return EventTypes;
        }


    }
}
