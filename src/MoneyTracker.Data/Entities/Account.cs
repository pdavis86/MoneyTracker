using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Data.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public bool Obsolete { get; set; }
    }
}
