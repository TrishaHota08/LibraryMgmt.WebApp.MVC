using System.ComponentModel.DataAnnotations;

namespace LibraryMgmt.WebApp.MVC.Helper.CustomValidationAttributes
{

    public class PositiveNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // The value is null, which means it is not valid (required validation should be applied separately if needed).
                return new ValidationResult(ErrorMessage ?? "The field is required.");
            }

            // Check if the value is numeric and greater than zero.
            if (decimal.TryParse(value.ToString(), out decimal numericValue) && numericValue > 0)
            {
                // The value is valid (a positive number).
                return ValidationResult.Success;
            }

            // The value is not a positive number, return an error message.
            return new ValidationResult(ErrorMessage ?? "Please enter a valid positive number.");
        }
    }
}
