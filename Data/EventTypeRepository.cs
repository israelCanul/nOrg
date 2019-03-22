using System;
using System.Collections.Generic;
using System.Linq;
using narilearsi.ModelDB;
using narilearsi.Services;
using Microsoft.EntityFrameworkCore;

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
            var EventTypes = _context.EventType.FromSql("SELECT * FROM dbo.Event INNER JOIN EventType on dbo.Event.EventoEventTypeIdEventTypeId = EventType.EventTypeID").ToList();
            return EventTypes;
        }

    }
}
