using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Routine.API.Entities;
using Routine.API.ValidationAttributes;

namespace Routine.API.Models
{
    [EmployeeNoMustDifferentFromFirstName(ErrorMessage = "员工与编号要不一致")]
    public class EmployeeAddDto : IValidatableObject
    {
        [Display(Name = "员工号")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} {1}-{2}")]
        public string EmployeeNo { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Display(Name = "性别")] public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        // 自定义验证  跨属性 类级别验证
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName ==LastName)
            {
                yield return  new ValidationResult("firstName can't be the same as lastName",new []{nameof(FirstName),nameof(LastName)});
            }
        }
    }
}