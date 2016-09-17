using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoProj.Entities;

namespace DemoProj.Controllers
{
    public class RentInfoesController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: RentInfoes
        public ActionResult Index()
        {
            return View(db.RentInfoes.ToList());
        }

        // GET: RentInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentInfo rentInfo = db.RentInfoes.Find(id);
            if (rentInfo == null)
            {
                return HttpNotFound();
            }
            return View(rentInfo);
        }

        // GET: RentInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,RacketId,DateRented,DateToReturn")] RentInfo rentInfo)
        {
            if (ModelState.IsValid)
            {
                db.RentInfoes.Add(rentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentInfo);
        }

        // GET: RentInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentInfo rentInfo = db.RentInfoes.Find(id);
            if (rentInfo == null)
            {
                return HttpNotFound();
            }
            return View(rentInfo);
        }

        // POST: RentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,RacketId,DateRented,DateToReturn")] RentInfo rentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentInfo);
        }

        // GET: RentInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentInfo rentInfo = db.RentInfoes.Find(id);
            if (rentInfo == null)
            {
                return HttpNotFound();
            }
            return View(rentInfo);
        }

        // POST: RentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentInfo rentInfo = db.RentInfoes.Find(id);
            db.RentInfoes.Remove(rentInfo);
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
