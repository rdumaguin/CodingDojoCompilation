using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Validators
{
    public class FutureDateAttribute : ValidationAttribute // Attribute is simply "FutureDate"
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value?.GetType() != typeof(DateTime)) // Catching null value in the Model, Index, and CustomValidations
            {
                return new ValidationResult("Invalid Date");
            }
            return (DateTime)value < DateTime.Today ? new ValidationResult("The Date must be in the future.") : ValidationResult.Success; 
        }
    }
}