using System;
using System.Collections.Generic;
using narilearsi.EFModels;

namespace narilearsi.Services
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int eventID);
    }
}
