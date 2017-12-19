using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerDataModel.Entities
{
    public class TransactionCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public bool Obsolete { get; set; }
    }
}
