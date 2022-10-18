using AirLinesAp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace AirLinesAp.Controllers
{
    public class UserController : Controller
    {
        private readonly GigoAirlinesContext gi;
        private readonly ISession session;

        public UserController(GigoAirlinesContext _gi, IHttpContextAccessor httpContextAccessor)
        {
            gi=_gi;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Register(Login lo)

        {
            
            gi.Logins.Add(lo);
            gi.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login lo)
        {
            var result = (from i in gi.Logins
                         where i.UserName== lo.UserName&&i.PassWord==lo.PassWord
                         select i).SingleOrDefault();
            if (result!= null)
            {
                HttpContext.Session.SetString("Uname", lo.UserName);

                return RedirectToAction("BookingPage", "User");
            }
            else
            {
                return View("register");
            }

        }



        public IActionResult BookingPage(string Departure, string Arrival)
        {
            ViewBag.MyName=HttpContext.Session.GetString("Uname");
            ViewBag.DepartureList = (from i in gi.TravelLocations
                               join j in gi.BookingPages on i.CityId equals j.Departure
                               select i).Distinct();

            ViewBag.ArrivalList =(from i in gi.TravelLocations
                                 join j in gi.BookingPages on i.CityId equals j.Arrival
                                 select i).Distinct();

            ViewBag.timelist= from i in gi.BookingPages
                              select i.Starttime;

            if (Departure!=null)
            {
                
                var final = gi.FlightInformations.Where(i => i.Depature== Int32.Parse(Departure) && i.Arrival==Int32.Parse(Arrival)).ToList();
                return View("FlightInformation",final);
                
                
            }
            else
            {
               
                //var flight = gi.FlightInformations.ToList();
                return View();
            }





        }
        public IActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(Payment pa)
        {
            gi.Payments.Add(pa);
            gi.SaveChanges();
            return RedirectToAction("register");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}