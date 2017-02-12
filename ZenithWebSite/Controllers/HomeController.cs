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
            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events.All(b => b.IsActive == true))
                                .Select(a => a);
            return View(activities.ToList());
        }
    }
}