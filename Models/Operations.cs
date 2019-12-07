using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Operations
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public List<TransactionHistories> transactionHistories { get; set; }
    }
}
