using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUpGenius.Models;
using SignUpGenius.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenius.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private SignUpDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, SignUpDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpPage()
        {
            DayViewModel dayView = new DayViewModel
            {
                Monday = _context.AppointmentTime
                    .Where(x => x.Day == "Monday" && x.Scheduled == false),
                Tuesday = _context.AppointmentTime
                    .Where(x => x.Day == "Tuesday" && x.Scheduled == false),
                Wednesday = _context.AppointmentTime
                    .Where(x => x.Day == "Wednesday" && x.Scheduled == false),
                Thursday = _context.AppointmentTime
                    .Where(x => x.Day == "Thursday" && x.Scheduled == false),
                Friday = _context.AppointmentTime
                    .Where(x => x.Day == "Friday" && x.Scheduled == false),
                Saturday = _context.AppointmentTime
                    .Where(x => x.Day == "Saturday" && x.Scheduled == false),
                Sunday = _context.AppointmentTime
                    .Where(x => x.Day == "Sunday" && x.Scheduled == false)
            };

            return View(new MainPageModel
            {
                dayViewModel = dayView
            });
        }

        [HttpPost]
        public IActionResult SignUpPage(FormModel appResponse)
        {
            FormTempStorage.AddApplication(appResponse);
            string myTime = appResponse.Time;
            return RedirectToAction("SignUpForm", "Home", new { appTime = myTime });
            //return View("SignUpForm", appTime);
        }


        [HttpGet]
        public IActionResult SignUpForm(string appTime)
        {
            FormModel tempModel = new FormModel();
            tempModel.Time = appTime;
            return View(tempModel);
        }
        [HttpPost]
        public IActionResult SignUpForm(FormModel appResponse)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                _context.Form.Add(appResponse);
                _context.SaveChanges();
                // Still need to add other functionality in here
                return View("Index", appResponse);
            }
            else
            {
                //List out the validation errors without going to another page yet
                return View(appResponse);
            }
        }

        public IActionResult Appointments()
        {
            return View(_context.Form);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
