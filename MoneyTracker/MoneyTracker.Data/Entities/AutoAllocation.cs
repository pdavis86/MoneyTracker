using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Data.Entities
{
    public class AutoAllocation
    {
        [Key]
        public int AutoAllocationId { get; set; }

        [MaxLength(50)]
        public string GridColumnName { get; set; }

        [MaxLength(50)]
        public string GridDataPattern { get; set; }

        [MaxLength(50)]
        public string UpdateColumnName { get; set; }

        [MaxLength(50)]
        public string UpdateDataValue { get; set; }

    }
}
