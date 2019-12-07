using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Currencies
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="No more than 50 characters!")]
        public string name { get; set; }
        [Required]
        [StringLength(8)]
        public string short_name { get; set; }

        public List<Accounts> accounts { get; set; }

        public List<TransactionHistories> TransactionHistories { get; set; }

        public int currency_exchange_id { get; set; }
        [ForeignKey("currency_exchange_id")]
        public CurrencyExchange currencyExchange { get; set; }

        public int bank_total_balance_id { get; set; }
        [ForeignKey("bank_total_balance_id")]
        public BankTotalBalance bankTotalBalance { get; set; }

    }
}
