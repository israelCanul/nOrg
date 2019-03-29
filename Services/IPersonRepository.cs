using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelNari;
using narilearsi.ModelDB;

namespace narilearsi.Services
{
    public interface IPersonRepository
    {
        Task<List<Persons>> GetPersons();
        Task<Persons> GetPerson(int personId);
        Task<Persons> SetPerson(Persons person);
        OperationResultOutput UpdatePerson(int personId,Persons person);
        Task<string> DeletePerson(int personId);
    }
}
