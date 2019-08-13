using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Data.Entities
{
    public class TransactionCategory
    {
        [Key]
        public int CategoryId { get; set; }

        //todo: rename any descriptions to "name"
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public bool Obsolete { get; set; }
    }
}
