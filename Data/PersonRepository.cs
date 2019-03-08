using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi.Data
{
    public class PersonRepository : IPersonRepository
    {
        private IConfiguration _configuration;

        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<String> GetPersons()
        {
            using (StoredProcedure stProcedure = new StoredProcedure(_configuration,"GetPersons", "dbo")) {
                await stProcedure.executeAsync();
                return stProcedure.ToJson();
            }
        }
    }
}
