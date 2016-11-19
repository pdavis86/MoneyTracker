﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerDataModel.Entities
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? LeaveDate { get; set; }

        public bool Obsolete { get; set; }
    }
}
