using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Ninja
    {
        [Key]
        public int NinjaId {get;set;}
        [Required]
        [Display(Name="Ninja Name")]
        public string Name {get;set;}
        [Required]
        [Display(Name="Ninjaing Level (1-10)")]
        [Range(1, 10, ErrorMessage="Ninja Level must be between 1-10")]
        public int Level {get;set;}
        [Required]
        [Display(Name="Optional Description")]
        [MinLength(10, ErrorMessage="Description must be 10 or more characters")]
        public string Description {get;set;}
        [Required]
        [Display(Name="Assigned Dojo?")]
        public int DojoId {get;set;}
        public Dojo Dojo {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public Ninja()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}