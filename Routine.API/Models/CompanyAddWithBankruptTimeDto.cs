using System;

namespace Routine.API.Models
{
    public class CompanyAddWithBankruptTimeDto :CompanyAddDto
    {
        public DateTimeOffset? BankruptTime { get; set; }

    }
}