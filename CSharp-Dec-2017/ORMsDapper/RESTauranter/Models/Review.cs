using System;
using System.ComponentModel.DataAnnotations;
using RESTauranter.Validators;

namespace RESTauranter.Models
{
    public class Review
    {
        [Key]
        public int id {get;set;}

        [Required]
        [Display(Name="Reviewer Name")]
        public string reviewer {get;set;}

        [Required]
        [Display(Name="Restaurant Name")]
        public string restaurant {get;set;}

        [Required]
        [Display(Name="Stars")]
        [Range(1,5)]
        public short rating {get;set;}

        [Required]
        [Display(Name="Review")]
        [MinLength(11, ErrorMessage="Review must be longer than 10 characters")]
        public string content {get;set;}

        [Required]
        [Display(Name="Date of visit")]
        [DataType(DataType.Date)]
        [PastDate]
        public DateTime date_visited {get;set;}

        public DateTime created_at {get;set;}

        public DateTime updated_at {get;set;}

        public Review()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}