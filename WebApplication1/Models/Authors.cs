using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Authors{

        public int Id { get; set; }
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele autorului tre sa fie intre 3 si 50 de caractere, boss")]
        [Required()]
        [Display(Name = "Nume Autor")]

        public string AuthorName { get; set; }
        
        [Range(-2000, 2100)]
        [Required()]
        [Display(Name = "Anul nasterii")]

        public int Year { get; set; }
    }
}