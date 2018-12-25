using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication2.Models;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public MyDataSourceInBottle MyData = new MyDataSourceInBottle();
        [Authorize]
        public ActionResult AjaxShopIn(int pos, int count)
        {
            var g = User.Identity.GetUserId();
            var y = MyData.orderus.OrderBy(t => t.date_selling).Where(w=>w.customer_id == g).Skip(pos).Take(count).ToList();
            return PartialView(y);
        }
        [Authorize]
        public ActionResult AjaxShopOut(int pos, int count)
        {
            var g = User.Identity.GetUserId();
            var y = MyData.orderus.OrderBy(t => t.date_selling).Where(t => t.employer_id == g).Skip(pos).Take(count).ToList();
            return PartialView(y);
        }
        [Authorize]
        public ActionResult AjaxAll(int pos, int count)
        {
            var g = User.Identity.GetUserId();
            var y = MyData.orderus.OrderBy(t => t.date_selling).Where(t => t.employer_id == g|| t.customer_id == g).Skip(pos).Take(count).ToList();
            return PartialView(y);
        }

        public ActionResult AddLot()
        {
            var r = new LAD();
            r.Districts = MyData.district.ToList();
            r.LotsTypes = MyData.lots_type.ToList();
            return View(r);
        }

        public ActionResult AjaxStreet(string name)
        {
            var r = MyData.street.Where(t => t.district.district_def == name).ToList();
            return PartialView(r);
        }
    }
}