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
    public class RacketsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Rackets
        public ActionResult Index()
        {
            return View(db.Rackets.ToList());
        }

        // GET: Rackets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racket racket = db.Rackets.Find(id);
            if (racket == null)
            {
                return HttpNotFound();
            }
            return View(racket);
        }

        // GET: Rackets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rackets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Racket racket)
        {
            if (ModelState.IsValid)
            {
                db.Rackets.Add(racket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racket);
        }

        // GET: Rackets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racket racket = db.Rackets.Find(id);
            if (racket == null)
            {
                return HttpNotFound();
            }
            return View(racket);
        }

        // POST: Rackets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Racket racket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racket);
        }

        // GET: Rackets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racket racket = db.Rackets.Find(id);
            if (racket == null)
            {
                return HttpNotFound();
            }
            return View(racket);
        }

        // POST: Rackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racket racket = db.Rackets.Find(id);
            db.Rackets.Remove(racket);
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
