using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Accounts
    {
        [Key]
        public int id { get; set; }
        
        public string name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No more than 50 characters!")]
        public string first_name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No more than 50 characters!")]
        public string last_name { get; set; }
        
        [Range(0, 999999999)]
        public double amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime created_date { get; set; }

        public bool is_blocked { get; set; }

        public int currency_id { get; set; }
        [ForeignKey("currency_id")]
        public Currencies currency { get; set; }

        public List<TransactionHistories> transactionHistories { get; set; }
        public List<TransactionHistories> transaction_histories2 { get; set; }
    }
}
