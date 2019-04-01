using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelNari;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class PersonRepository : IPersonRepository
    {
        private IConfiguration _configuration;
        private DBContext _context;
        public PersonRepository(IConfiguration configuration, DBContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        /*** DELETE -*/
        public Task<string> DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }



        /*** SET -*/
        public async Task<Persons> SetPerson(Persons person)
        {
            var newPerson = new Persons()
            {
                Name = person.Name,
                LastName = person.LastName,
                Password = person.LastName,
                Email = person.Email,
                status = "ACTIVE"
            };
            _context.Add<Persons>(newPerson);
            var res = _context.SaveChanges();
            return newPerson;
        }
        /*** UPDATE -*/
        public OperationResultOutput UpdatePerson(int personId, Persons person)
        {
            var result = new OperationResultOutput();
            var getPerson = _context.Persons.Where(c => c.PersonID == personId).FirstOrDefault();
            if (getPerson == null) {
                result.code = -1;
                result.desc = "The person doesn't exist";
                return result;
            }
            if (getPerson.status != "ACTIVE") {
                result.code = -1;
                result.desc = "The person is not Active";
                return result;
            }
            getPerson.Name = person.Name;
            getPerson.LastName = person.LastName;
            getPerson.Password = person.Password;
            getPerson.Email = person.Email;
            _context.SaveChanges();
            result.code = 1;
            result.desc = "Person updated";
            return result;
        }
        /*** GET -*/
        async Task<List<Persons>> IPersonRepository.GetPersons()
        {
            return _context.Persons.Include(c => c.Event).Where(c => c.status != "INACTIVE").ToList();
        }
        public async Task<Persons> GetPerson(int personId)
        {
            return _context.Persons.Where(c => c.PersonID == personId).FirstOrDefault();
        }
    }
}
