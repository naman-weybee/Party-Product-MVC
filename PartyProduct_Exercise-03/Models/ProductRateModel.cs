using PartyProduct_Exercise_03.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Models
{
    public class ProductRateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please add Rate of Product")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Please add Date of Rate")]
        public DateTime DateOfRate { get; set; }
    }
}
