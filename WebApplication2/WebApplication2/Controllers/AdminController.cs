using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        private MyDataSourceInBottle MyData = new MyDataSourceInBottle();
        public ActionResult AjaxUsers(string nameuser, int numb, int count)
        {
            var val = numb * count;
            var str = "select * from AspNetUsers WHERE UserName LIKE '" + nameuser + "%'" +
                      " order by dbo.AspNetUsers.Id DESC offset " + val + " rows fetch next " + count + " rows only";
            var allbooks = MyData.Database.SqlQuery<AspNetUsers>(str).ToList();
            return PartialView(allbooks);
        }
        public ActionResult AjaxGoods(string nameuser, int numb, int count)
        {
            var allbooks = new List<orderus>();
            var val = numb * count;
            switch (nameuser)
            {
                case "":
                    allbooks = MyData.orderus.OrderBy(t => t.date_selling).Skip(numb).Take(count).ToList();
                    break;
                default:
                    allbooks = MyData.orderus.OrderBy(t => t.date_selling).Where(t => t.AspNetUsers1.UserName.Contains(nameuser) || t.lot.name_lot.Contains(nameuser)).Skip(numb).Take(count).ToList();
                    break;
            }
            
            return PartialView(allbooks);
        }

        public void DeletedGoods(int id, int id1)
        {
            MyData.Database.ExecuteSqlCommand("DELETE FROM dbo.orderus WHERE id =" + id);
            MyData.Database.ExecuteSqlCommand("DELETE FROM dbo.lot WHERE id =" + id1);
        }

        public void TrueOrder(int id)
        {
            MyData.Database.ExecuteSqlCommand("UPDATE dbo.orderus SET vir = 'True' WHERE id ="+id);
        }
        public ActionResult AjaxStreet(string nameuser, int numb, int count)
        {
            var allbooks = new List<street>();
            var val = numb * count;
            switch (nameuser)
            {
                case "":
                    allbooks = MyData.street.OrderBy(t => t.id).Skip(numb).Take(count).ToList();
                    break;
                default:
                    allbooks = MyData.street.OrderBy(t => t.id).Where(t => t.street_def.Contains(nameuser)).Skip(numb).Take(count).ToList();
                    break;
            }
            return PartialView(allbooks);
        }
        public ActionResult AjaxDis(string nameuser, int numb, int count)
        {
            var allbooks = new List<district>();
            var val = numb * count;
            switch (nameuser)
            {
                case "":
                    allbooks = MyData.district.OrderBy(t => t.id).Skip(numb).Take(count).ToList();
                    break;
                default:
                    allbooks = MyData.district.OrderBy(t => t.id).Where(t => t.district_def.Contains(nameuser)).Skip(numb).Take(count).ToList();
                    break;
            }
            return PartialView(allbooks);
        }
        public void UploadType(string name, string index)
        {
            MyData.Database.ExecuteSqlCommand("UPDATE street SET street_def = N'" + name + "' WHERE id =" + index);
        }
        public void UploadDis(string name, string index)
        {
            MyData.Database.ExecuteSqlCommand("UPDATE district SET district_def = N'" + name + "' WHERE id =" + index);
        }

    }
}