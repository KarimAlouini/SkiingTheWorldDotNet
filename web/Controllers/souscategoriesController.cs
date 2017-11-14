using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkiingTheWorld_PI.Domaine.Entities;
using domaine.entities;

namespace web.Controllers
{
    public class souscategoriesController : Controller
    {
        private SWModel db = new SWModel();

        // GET: souscategories
        public ActionResult Index()
        {
            return View(db.souscategories.ToList());
        }

        // GET: souscategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            souscategorie souscategorie = db.souscategories.Find(id);
            if (souscategorie == null)
            {
                return HttpNotFound();
            }
            return View(souscategorie);
        }

        // GET: souscategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: souscategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,libelle")] souscategorie souscategorie)
        {
            if (ModelState.IsValid)
            {
                db.souscategories.Add(souscategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(souscategorie);
        }

        // GET: souscategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            souscategorie souscategorie = db.souscategories.Find(id);
            if (souscategorie == null)
            {
                return HttpNotFound();
            }
            return View(souscategorie);
        }

        // POST: souscategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,libelle")] souscategorie souscategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(souscategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(souscategorie);
        }

        // GET: souscategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            souscategorie souscategorie = db.souscategories.Find(id);
            if (souscategorie == null)
            {
                return HttpNotFound();
            }
            return View(souscategorie);
        }

        // POST: souscategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            souscategorie souscategorie = db.souscategories.Find(id);
            db.souscategories.Remove(souscategorie);
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
