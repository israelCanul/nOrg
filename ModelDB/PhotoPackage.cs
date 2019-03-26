using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace narilearsi.ModelDB
{
    public class PhotoPackage
    {
        public int photoPackageId { get; set; }
        public string ppName { get; set; }
        public string ppDescription { get; set; }
        public int EventId { get; set; }// fk

        public ICollection<ItemPackage> itemPackage { get; set; }
    }
}
