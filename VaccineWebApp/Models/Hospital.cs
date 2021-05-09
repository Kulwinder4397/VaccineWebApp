using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineWebApp.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Hospital Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Hospital Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        public virtual ICollection<Booking> HospitalBookings { get; set; }
    }
}
