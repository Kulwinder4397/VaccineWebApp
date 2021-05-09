using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccineWebApp.Data;
using VaccineWebApp.Models;

namespace VaccineWebApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class PersonalDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalDetails.ToListAsync());
        }        
    }
}
