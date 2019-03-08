using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using narilearsi.ModelDB;

namespace narilearsi.Services
{
    public interface IPersonRepository
    {
        Task<String> GetPersons();
    }
}
