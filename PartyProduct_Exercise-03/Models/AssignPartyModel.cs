using PartyProduct_Exercise_03.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Models
{
    public class AssignPartyModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Party")]
        public int PartyId { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        public int ProductId { get; set; }

        public string productName { get; set; }
        public Party Party { get; set; }
        public Product Product { get; set; }
    }
}
