using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatRental
{
    public static class ValidationExtensions
    {
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> ValidationResults)
        {
            var validationContext = new ValidationContext(instance);
            ValidationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, ValidationResults, true);
        }
    }
}