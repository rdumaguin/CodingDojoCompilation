using System;
using System.ComponentModel.DataAnnotations;

namespace Form_Submission.Models
{
    public class User
    {
        [Display(Name="First Name")]
        [Required(ErrorMessage="First Name is required.")]
        [MinLength(4, ErrorMessage="First Name must be 4 or more characters.")]
        public string first_name {get;set;}
        [Display(Name="Last Name")]
        [Required(ErrorMessage="Last Name is required.")]
        [MinLength(4, ErrorMessage="Last Name must be 4 or more characters.")]
        public string last_name {get;set;}
        [Display(Name="Age")]
        [Required(ErrorMessage="Age is required.")]
        [Range(0, Int32.MaxValue, ErrorMessage="Age must be a positive number.")]
        public int age {get;set;}
        [Display(Name="Email")]
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress(ErrorMessage="Email is invalid.")]
        public string email {get;set;}
        [Display(Name="Password")]
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters.")]
        public string password {get;set;}
    }

}