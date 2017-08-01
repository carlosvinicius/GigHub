using GigHub.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                                    .Include(global => global.Artist)
                                    .Include(global => global.Genre)
                                    .Where(g => g.DateTime > DateTime.Now);

            ViewBag.Heading = "Upcoming Gigs";

            return View("Gigs", upcomingGigs);
        }

    }
}