using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the Model object
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            // Fail validation when BirthdayDate is null and MembershipTypeId is not 0 or 1
            if (customer.BirthdayDate == null)
            {
                return new ValidationResult("Date of Birth is required");
            }

            var age = DateTime.Now.Year - customer.BirthdayDate.Value.Year;

            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer should be at least 18 years old for membership");
            }
        }
    }
}