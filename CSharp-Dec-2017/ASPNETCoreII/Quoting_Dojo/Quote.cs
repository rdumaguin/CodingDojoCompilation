using System.ComponentModel.DataAnnotations;

namespace Quoting_Dojo.Models
{
    public class Quote
    {
        [Display(Name="Your name:")]
        [Required(ErrorMessage="Name is required.")]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters.")]
        public string author {get;set;}
        [Display(Name="Your quote:")]
        [Required(ErrorMessage="Please enter a quote.")]
        [MinLength(1, ErrorMessage="Quote must be 1 or more characters.")]
        public string content {get;set;}
    }

}