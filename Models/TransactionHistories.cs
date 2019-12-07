using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class TransactionHistories: IValidatableObject
    {
        [Key]
        public int id { get; set; }
        //[Required]
        //public int manager_id { get; set; }
        //[ForeignKey("manager_id")]
        //public Users manager { get; set; }

        [Required]
        public int sender_account_id { get; set; }
        [ForeignKey("sender_account_id")]
        public Accounts senderAccount { get; set; }

        [Required]
        public int receiver_account_id { get; set; }
        [ForeignKey("receiver_account_id")]
        public Accounts receiverAccount { get; set; }

        [Required]
        public int operation_id { get; set; }
        [ForeignKey("operation_id")]
        public Operations operation { get; set; }

        [Required]
        public int currency_id { get; set; }
        [ForeignKey("currency_id")]
        public Currencies currency { get; set; }

        [Required]
        [Range(0, 99999999)]
        public double amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime operation_time { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (sender_account_id == receiver_account_id)
            {
                yield return new ValidationResult(
                    "You cannot transfer money to yourself",
                    new[] { nameof(sender_account_id), nameof(receiver_account_id) });
            }
        }
    }
}
