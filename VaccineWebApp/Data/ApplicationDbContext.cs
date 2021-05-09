using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineWebApp.Models;

namespace VaccineWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
