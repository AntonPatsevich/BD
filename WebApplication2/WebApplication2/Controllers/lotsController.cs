using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ModelsDB;

namespace WebApplication2.Controllers
{
    public class lotsController : Controller
    {
        private Realt db = new Realt();

        // GET: lots
        public ActionResult Index()
        {
            var lot = db.lot.Include(l => l.district_id).Include(l => l.lots_type).Include(l => l.street);
            return View(lot.ToList());
        }

        // GET: lots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lot lot = db.lot.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // GET: lots/Create
        public ActionResult Create()
        {
            ViewBag.district_id = new SelectList(db.district, "id", "district_def");
            ViewBag.typeid = new SelectList(db.lots_type, "id", "Type_Def");
            ViewBag.street_id = new SelectList(db.street, "id", "street_def");
            return View();
        }

        // POST: lots/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,Descriptionn,price,area,typeid,likes,street_id,number_house,number_flat,count_rooms,district_id,Raiting,Metro_stations")] lot lot)
        {
            if (ModelState.IsValid)
            {
                db.lot.Add(lot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.district_id = new SelectList(db.district, "id", "district_def", lot.district_id);
            ViewBag.typeid = new SelectList(db.lots_type, "id", "Type_Def", lot.typeid);
            ViewBag.street_id = new SelectList(db.street, "id", "street_def", lot.street_id);
            return View(lot);
        }

        // GET: lots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lot lot = db.lot.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            ViewBag.district_id = new SelectList(db.district, "id", "district_def", lot.district_id);
            ViewBag.typeid = new SelectList(db.lots_type, "id", "Type_Def", lot.typeid);
            ViewBag.street_id = new SelectList(db.street, "id", "street_def", lot.street_id);
            return View(lot);
        }

        // POST: lots/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,Descriptionn,price,area,typeid,likes,street_id,number_house,number_flat,count_rooms,district_id,Raiting,Metro_stations")] lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.district_id = new SelectList(db.district, "id", "district_def", lot.district_id);
            ViewBag.typeid = new SelectList(db.lots_type, "id", "Type_Def", lot.typeid);
            ViewBag.street_id = new SelectList(db.street, "id", "street_def", lot.street_id);
            return View(lot);
        }

        // GET: lots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lot lot = db.lot.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // POST: lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lot lot = db.lot.Find(id);
            db.lot.Remove(lot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
