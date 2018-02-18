using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class RegisterViewModel
    {
        [Display(Name="First Name")]
        [Required(ErrorMessage="First Name is required.")]
        [MinLength(2, ErrorMessage="First Name must be 2 or more characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]       
        public string FirstName {get;set;}

        [Display(Name="Last Name")]
        [Required(ErrorMessage="Last Name is required.")]
        [MinLength(2, ErrorMessage="Last Name must be 2 or more characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]        
        public string LastName {get;set;}

        // [Display(Name="Age")]
        // [Required(ErrorMessage="Age is required.")]
        // [Range(0, Int32.MaxValue, ErrorMessage="Age must be a positive number.")]
        // public int Age {get;set;}

        [Display(Name="Email")]
        [Required(ErrorMessage="Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Email is invalid.")]
        public string Email {get;set;}

        [Display(Name="Password")]
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string Confirm {get;set;}
    }
}