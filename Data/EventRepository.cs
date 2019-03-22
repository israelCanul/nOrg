using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using narilearsi.EFModels;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class EventRepository:IEventRepository
    {
        private narilearsiContext _context;
        public EventRepository(narilearsiContext context)
        {
            _context = context;
        }

        public Event GetEvent(int eventID)
        {
            return _context.Event.Where(c => c.EventId == eventID).SingleOrDefault();
        }

        public IEnumerable<Event> GetEvents()
        {
            var res = _context.Event.ToList();
            return res;
        }
    }
}
