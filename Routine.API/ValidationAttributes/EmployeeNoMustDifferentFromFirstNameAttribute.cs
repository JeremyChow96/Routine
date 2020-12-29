using System;
using System.ComponentModel.DataAnnotations;
using Routine.API.Models;

namespace Routine.API.ValidationAttributes
{
    public class EmployeeNoMustDifferentFromFirstNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var addDot = validationContext.ObjectInstance as EmployeeAddDto;
            if (addDot == null) throw new ArgumentNullException(nameof(addDot));
            if (addDot.EmployeeNo == addDot.LastName)
            {
                return  new ValidationResult(ErrorMessage,new []{nameof(EmployeeAddDto)});
            }
            return  ValidationResult.Success;
            
        }
    }
}