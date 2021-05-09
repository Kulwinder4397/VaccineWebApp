using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineWebApp.Models
{
    public class Faq
    {
        [Key]
        public int FaqID { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Answer")]
        public string Answer { get; set; }
    }
}
