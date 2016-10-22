using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerDataModel.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int AccountId {get; set;}

        public int CategoryId { get; set; }

        public int TypeId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Value { get; set; }

        public decimal Balance { get; set; }


        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TransactionCategory Category { get; set; }

        [ForeignKey("TypeId")]
        public virtual TransactionType Type { get; set; }
    }
}
