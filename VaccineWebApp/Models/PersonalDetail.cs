using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineWebApp.Models
{
    public class PersonalDetail
    {
        [Key]
        public int PersonalDetailID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Person Name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Person Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }
        
    }

    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
