using System;
using System.Collections.Generic;
using narilearsi.ModelDB;

namespace narilearsi.Services
{
    public interface IEventTypeRepository
    {
        IEnumerable<EventType> GetEventTypes();
        EventType GetEvent(int eventTypeID);
    }
}
