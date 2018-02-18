using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Validators; // FutureDate

namespace WeddingPlanner.Models
{
    public class WeddingPlanned
    {
        [Key]
        public int WeddingId {get;set;}
        [Required]
        [Display(Name="Wedder One")]
        [MinLength(2, ErrorMessage="Wedder One's name must be 2 or more characters")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string WedderOne {get;set;}
        [Required]
        [Display(Name="Wedder Two")]
        [MinLength(2, ErrorMessage="Wedder Two's name must be 2 or more characters")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string WedderTwo {get;set;}
        [Required]
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime? Date {get;set;} // Catching null value in the Model, Index, and CustomValidations
        [Required]
        [Display(Name="Wedding Address")]
        public string Address {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public int UserId {get;set;}
        public User Planner {get;set;}
        public List<RSVP> RSVPdGuests {get;set;}
        public WeddingPlanned()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            RSVPdGuests = new List<RSVP>();
        }
    }
}