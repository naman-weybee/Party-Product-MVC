using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Data
{
    public class AssignParty
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public Party Party { get; set; }
        public Product Product { get; set; }
    }
}
