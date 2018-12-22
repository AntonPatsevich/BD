using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        RealtO db1 = new RealtO();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult lots()
        {

            var x = db1.lot.ToList();

            return View(x);

        }
        [Authorize]
        public ActionResult Lot(int id)
        {
            var x = db1.lot.Where(T => T.id == id).ToList();

            return View(x);

        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}