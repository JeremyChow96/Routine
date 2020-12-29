using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Routine.API.Services;

namespace Routine.API.Entities
{
 
    
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [StringLength(500)]
        public string Introduction { get; set; }

        public string Country { get; set; }
        public string Industry { get; set; }
        public string Product { get; set; }

        public DateTimeOffset? BankruptTime { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}