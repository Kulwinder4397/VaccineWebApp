using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineWebApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        public int HospitalID { get; set; }

        [ForeignKey("HospitalID")]
        [InverseProperty("HospitalBookings")]
        public Hospital Hospital { get; set; }

    }
}
