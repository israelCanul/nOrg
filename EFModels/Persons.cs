using System;
using System.Collections.Generic;

namespace narilearsi.EFModels
{
    public partial class Persons
    {
        public int PersonId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Adress2 { get; set; }
    }
}
