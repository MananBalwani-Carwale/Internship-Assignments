using System;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.Utils;
public class ValidMakeYearAttribute : ValidationAttribute
{
    public ValidMakeYearAttribute()
    {
        // Set the error message for the attribute
        ErrorMessage = "MakeYear must be between 1901 and the current year.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int makeYear)
        {
            // Get the current year at runtime
            int currentYear = DateTime.Now.Year;

            if (makeYear < 1901 || makeYear > currentYear)
            {
                return new ValidationResult($"MakeYear must be between 1901 and {currentYear}.", new[] { validationContext.MemberName });
            }
        }
        // If valid or null, return success
        return ValidationResult.Success;
    }
}