using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Routine.API.Entities;

namespace Routine.API.Models
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        //public string Country { get; set; }
        //public string Industry { get; set; }
        //public string Product { get; set; }


    }
}