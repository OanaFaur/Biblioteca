using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        [Required()]
        [Display(Name = "Titlu")]

        public string Name { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele autorului tre sa fie intre 3 si 50 de caractere, boss")]
        [Required()]
        [Display(Name = "Nume Autor")]

        public string AuthorName { get; set; }

        [Display(Name = "Numar")]
        int i = 1;
        public int Numar
        {

            get { return this.i; }




            set { this.i = value; }
        }

        

        public string ISBN { get; set; }

        [Range(-2000, 2100)]
        [Required()]
        [Display(Name = "Anul publicatiei")]

        public int Year { get; set; }
    }
}