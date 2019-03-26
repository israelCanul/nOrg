using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace narilearsi.ModelDB
{
    public class Persons
    {
        public Persons()
        {

        }
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
