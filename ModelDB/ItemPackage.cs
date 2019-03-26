using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace narilearsi.ModelDB
{
    public class ItemPackage
    {
        public int itemPackageId { get; set; }
        public int itemTypeId { get; set; }// fk
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string itemSize { get; set; }
        public string itemNotes { get; set; }
        public int packageId { get; set; }// fk   

        public ICollection<Item> Items { get; set; }
    }
}
