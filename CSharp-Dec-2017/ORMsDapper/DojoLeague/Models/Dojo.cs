using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Dojo
    {
        public int DojoId {get;set;}

        [Required]
        [Display(Name="Dojo Name")]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters")]
        public string Name {get;set;}

        [Required]
        [Display(Name="Dojo Location")]
        public string Location {get;set;}

        [Required]
        [Display(Name="Additional Dojo Information")]
        [MinLength(10, ErrorMessage="Description must be 10 or more characters")]
        public string AdditionalInfo {get;set;}

        public List<Ninja> Members {get;set;}

        public DateTime CreatedAt {get;set;}

        public DateTime UpdatedAt {get;set;}

        public Dojo()
        {
            Members = new List<Ninja>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}