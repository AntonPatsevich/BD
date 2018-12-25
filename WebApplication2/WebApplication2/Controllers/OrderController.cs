using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication2.Models;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        private MyDataSourceInBottle MyData = new MyDataSourceInBottle();
        public ActionResult ViewOrder(int id)
        {
            var w = MyData.lot.First(t => t.id == id);
            return View(w);
        }



        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string cat_string(string str)
        {
            return str.Replace(" ", string.Empty);
        }
        public string createRandFolder(string name)
        {
            name = cat_string(name);
            string OnePath = "~/UserMedia/Goods/";
            while (true)
            {
                string path = Path.Combine(Server.MapPath(OnePath), RandomString(10) + "_" + name);
                if (!Directory.Exists(path))
                {
                    var pathFolder = Directory.CreateDirectory(path);
                    return pathFolder.ToString();
                }
            }

        }

        public string MultiUpload(System.Web.HttpPostedFileWrapper FileBytes, string ConType, string NameFile, int pos, string folderName)
        {
            int len = FileBytes.ContentLength;
            var buf = new byte[len];
            FileBytes.InputStream.Read(buf, 0, len);
            string OnePath = "~/UserMedia/Goods/" + folderName + "/";
            string fileName = Path.GetFileName(NameFile);
            string newpath = Path.Combine(Server.MapPath(OnePath), fileName);
            using (FileStream fs = System.IO.File.Open(newpath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                fs.Position = pos;
                fs.Write(buf, 0, len);
            }
            return "test";
        }

        [Authorize]
        public void AddLot(AddL A)
        {
            var rid = MyData.street
                .First(t => t.street_def == A.street && t.district.district_def == A.district).id;
            var Tid = MyData.lots_type.First(t => t.Type_Def == A.type).id;
            var L = new lot
            {
                name_lot = A.name,
                Descriptionn = A.dis,
                area = Convert.ToInt32(A.aria),
                userId = User.Identity.GetUserId(),
                FolderImg = A.img_folder,
                count_rooms = Convert.ToInt32(A.count_rooms),
                number_flat = Convert.ToInt32(A.num_flat),
                number_house = Convert.ToInt32(A.num_house),
                likes = 0,
                price = Convert.ToInt32(A.price),
                street_id = rid,
                typeid = Tid
            };
            MyData.lot.Add(L);
            MyData.SaveChanges();
            var Uid = User.Identity.GetUserId();
            
var gg = MyData.lot.First(T => T.FolderImg == A.img_folder).id;
            var fd = new orderus
            {
                date_selling = DateTime.Now,
                lot_id = gg,
                employer_id = User.Identity.GetUserId()
            };
            MyData.orderus.Add(fd);
            MyData.SaveChanges();
        }
        [Authorize(Roles = "user")]
        public ActionResult AddOrder(int Id)
        {
            var SQL_str = "UPDATE dbo.orderus SET customer_id = N'"+User.Identity.GetUserId()+"' WHERE lot_id ="+Id;
            MyData.Database.ExecuteSqlCommand(SQL_str);
            return RedirectToAction("Index", "Manage");
        }
    }
}