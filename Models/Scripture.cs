using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scripture_Project.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        
        public string Verse { get; set; }

        public string Content { get; set; }

        [Display(Name = "Entry Date"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Book { get; set; }


    }

    

}
