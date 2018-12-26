using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public MyDataSourceInBottle db1 = new MyDataSourceInBottle();
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
            var x = new AllThis();
            x.Districts = db1.district.ToList();
            x.LotsTypes = db1.lots_type.ToList();
            return View(x);

        }
        [Authorize]
        public ActionResult Lot(int pos, int count, string nameS, decimal price, string typeO, int typeG, string dis)
        {
            var allgoods = new List<lot>();
            if (typeG == 2)
            {
                allgoods = db1.lot
                    .Where(t => t.price <= price && (t.Descriptionn.Contains(nameS) || t.name_lot.Contains(nameS)) &&
                                t.lots_type.Type_Def == typeO && t.street.district.district_def == dis)
                    .OrderBy(t => t.price).Skip(pos).Take(count).ToList();
            }
            if (price == 3)
            {
                allgoods = db1.lot
                    .Where(t => t.price <= price && (t.Descriptionn.Contains(nameS) || t.name_lot.Contains(nameS)) &&
                                t.lots_type.Type_Def == typeO && t.street.district.district_def == dis)
                    .OrderByDescending(t => t.price)
                    .Skip(pos).Take(count).ToList();
            }
            return PartialView(allgoods);
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





    }
}