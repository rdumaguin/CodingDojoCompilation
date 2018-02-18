using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Validators
{
    public class PastDateAttribute : ValidationAttribute // Attribute is simply "PastDate"
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value.GetType() != typeof(DateTime))
            {
                return new ValidationResult("Invalid Date");
            }
            return (DateTime)value > DateTime.Today ? new ValidationResult("Date field cannot be a future date") : ValidationResult.Success; 
        }
    }
}