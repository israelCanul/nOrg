using System;
using System.Collections.Generic;
using narilearsi.ModelDB;

namespace narilearsi.Services
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int eventID);
        Event SetEvent();
    }
}
