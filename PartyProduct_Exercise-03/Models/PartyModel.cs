using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PartyProduct_Exercise_03.Models
{
    public class PartyModel
    {
        public int Id { get; set; }

        [Display(Name = "Party Name")]
        [Required(ErrorMessage = "Please Enter Party Name")]
        public string PartyName { get; set; }
    }
}
