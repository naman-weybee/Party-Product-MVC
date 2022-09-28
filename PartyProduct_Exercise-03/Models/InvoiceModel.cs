using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Party Name")]
        [Required(ErrorMessage = "Please Select Party")]
        public int PartyId { get; set; }
        public string PartyName { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Select Product")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Current Rate")]
        [Required(ErrorMessage = "Please Enter Current Rate Of Product")]
        public int CurrentRate { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
