using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VaccineWebApp.Data;
using VaccineWebApp.Models;

namespace VaccineWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _environment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllFaq()
        {
            return View(await _context.Faqs.ToListAsync());
        }

        public async Task<IActionResult> AllHospital()
        {
            return View(await _context.Hospitals.ToListAsync());
        }

        [Authorize]
        public IActionResult VaccineBooking()
        {
            string userid = _userManager.GetUserName(this.User);
            var details = _context.PersonalDetails
                .Where(m => m.UserID == userid);
            if(details.Count() == 0)
            {
                return RedirectToAction(nameof(AddPersonDetail));
            }
            ViewData["HospitalID"] = new SelectList(_context.Hospitals, "HospitalID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VaccineBooking([Bind("BookingID,BookingDate,HospitalID")] Booking booking)
        {
            ModelState.Remove("UserID");
            if (ModelState.IsValid)
            {
                string userid = _userManager.GetUserName(this.User);
                var bookings = _context.Bookings
                .Where(m => m.UserID == userid);
                if(bookings.Count() == 2)
                {
                    ModelState.AddModelError("BookingDate", "You Allowed For Only Two Vaccine Bookings");
                }
                else
                {
                    booking.UserID = userid;
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(MyBookings));
                }
            }
            ViewData["HospitalID"] = new SelectList(_context.Hospitals, "HospitalID", "Name", booking.HospitalID);
            return View(booking);
        }

        [Authorize]
        public IActionResult AddPersonDetail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPersonDetail([Bind("PersonalDetailID,Name,Address,ContactNo,File")] PersonalDetail personalDetail)
        {
            using (var memoryStream = new MemoryStream())
            {
                await personalDetail.File.FormFile.CopyToAsync(memoryStream);

                string photoname = personalDetail.File.FormFile.FileName;
                personalDetail.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(personalDetail.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            ModelState.Remove("UserID");
            if (ModelState.IsValid)
            {
                personalDetail.UserID = _userManager.GetUserName(this.User);    
                _context.Add(personalDetail);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "person");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = personalDetail.PersonalDetailID + personalDetail.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await personalDetail.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(MyDetails));
            }
            return View(personalDetail);
        }

        [Authorize]
        public async Task<IActionResult> MyDetails()
        {
            string userid = _userManager.GetUserName(this.User);
            var details = await _context.PersonalDetails
                .Where(m => m.UserID == userid).ToListAsync();
            return View(details);
        }

        [Authorize]
        public async Task<IActionResult> MyBookings()
        {
            string userid = _userManager.GetUserName(this.User);
            var bookings = await _context.Bookings
                .Include(m => m.Hospital)
                .Where(m => m.UserID == userid).ToListAsync();
            return View(bookings);
        }

        [Authorize]
        public async Task<IActionResult> CancelBooking(int? id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyBookings));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
