using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class BankTotalBalance
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double value { get; set; }
        [Required]
        public int currency_id { get; set; }
        [ForeignKey("currency_id")]
        public Currencies currency { get; set; }
    }
}
