using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithWebSite.Models;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //db 

        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            DateTime first = today.AddDays(-(int)today.DayOfWeek);
            DateTime last = first.AddDays(7);

            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events.Any(b => b.EventFrom >= first && b.EventFrom <= last && b.IsActive == true))
                                .Select(a => a);
            return View(activities.ToList());
        }
    }
}