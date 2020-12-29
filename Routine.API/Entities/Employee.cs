using System;
using System.ComponentModel.DataAnnotations;

namespace Routine.API.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        [Required]
        [StringLength(10)]
        public string EmployeeNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Company Company { get; set; }
    }
}