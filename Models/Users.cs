using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Users : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage ="No more than 50 characters!")]
        [Remote(action:"VerifyName", controller:"Users")]
        public string full_name { get; set; }

        //public List<TransactionHistories> transactionHistories { get; set; }
    }
}
