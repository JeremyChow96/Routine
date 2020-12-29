using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Routine.API.Entities;

namespace Routine.API.Models
{
    public class EmployeeUpdateDto
    {
         [Display(Name = "员工号")]
         [Required(ErrorMessage = "{0}是必填项")]
         [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} {1}-{2}")]
        public string EmployeeNo { get; set; }

          [Required] 
        public string FirstName { get; set; }

         [Required]
        public string LastName { get; set; }

         [Display(Name = "性别")]
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}