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
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
