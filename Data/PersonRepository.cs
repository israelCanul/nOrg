using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class PersonRepository : IPersonRepository
    {
        private IConfiguration _configuration;
        private DBContext _context;
        public PersonRepository(IConfiguration configuration,DBContext context)
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
                Email = person.Email
            };
            _context.Add<Persons>(newPerson);
            var res = _context.SaveChanges();
            return newPerson;
        }
        /*** UPDATE -*/
        public Task<string> UpdatePerson(Persons person)
        {
            throw new NotImplementedException();
        }
        /*** GET -*/
        async Task<List<Persons>> IPersonRepository.GetPersons()
        {
            return _context.Persons.ToList();
        }
    }
}
