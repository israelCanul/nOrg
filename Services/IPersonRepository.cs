using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using narilearsi.ModelDB;

namespace narilearsi.Services
{
    public interface IPersonRepository
    {
        Task<List<Persons>> GetPersons();
        Task<Persons> SetPerson(Persons person);
        Task<string> UpdatePerson(Persons person);
        Task<string> DeletePerson(int personId);
    }
}
