using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTracker.Data.Entities
{
    public class PaySlip
    {
        [Key]
        public int PaySlipId { get; set; }

        public int EmployerId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public decimal Basic { get; set; }

        public decimal? SspSmpSpp { get; set; }

        public decimal? Overtime { get; set; }

        public decimal? Bonus { get; set; }

        public decimal? UnpaidPay { get; set; }

        public decimal? BackPay { get; set; }

        public decimal? HolidayPay { get; set; }

        public decimal Tax { get; set; }

        public decimal NationalInsurance { get; set; }

        public decimal? Pension { get; set; }

        public decimal? StudentLoan { get; set; }

        public decimal Net { get; set; }


        [ForeignKey("EmployerId")]
        public virtual Employer Employer { get; set; }
    }
}
