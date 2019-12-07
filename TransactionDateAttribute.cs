using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public class TransactionDateAttribute: ValidationAttribute
    {
        public TransactionDateAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Transaction time must be no later than {Year}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var transaction = (TransactionHistories)validationContext.ObjectInstance;
            var operation_time = ((DateTime)value).Year;

            if (operation_time > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
