using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class CurrencyExchange
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int currency_id { get; set; }
        [ForeignKey("currency_id")]
        public Currencies currency { get; set; }
        [Required]
        public double purchase_value { get; set; }
        [Required]
        public double sale_value { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime assigned_time { get; set; }
    }
}
