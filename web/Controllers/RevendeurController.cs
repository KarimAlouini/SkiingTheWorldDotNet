using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using SpecificServices;
using web.Models;

namespace web.Controllers
{

    public class RevendeurController : Controller
    {
        RevendeurService rvs = new RevendeurService();
        private SWModel db = new SWModel();

        // GET: Revendeur
        public ActionResult Index()
        {
            return View(db.seller.ToList());
        }

        // GET: Revendeur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seller seller = db.seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // GET: Revendeur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revendeur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(RevendeurModel collection, HttpPostedFileBase File)
        {

            seller s1 = new seller
            {

                name = collection.Name,
                phoneNumber = collection.tel,
                email = collection.Email,
                latitude = collection.Latitude,
                longitude = collection.Longitude,
                ImageName = collection.ImageName
            };



            if (File.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(new Random().Next().ToString() + File.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Upload"), _FileName);

                File.SaveAs(path);
                s1.ImageName = _FileName;
            }


            rvs.Add(s1);
            rvs.Commit();

            return RedirectToAction("Index");


        }

        // GET: Revendeur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seller seller = db.seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Revendeur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,latitude,longitude,email,name,phoneNumber,ImageName")] seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seller);
        }

        // GET: Revendeur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seller seller = db.seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Revendeur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seller seller = db.seller.Find(id);
            db.seller.Remove(seller);
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

        public ActionResult AllSellers()
        {
            user u = (user)Session["user"];

            return View();
        }

        public string GetSellersJson()
        {
            RevendeurService s = new RevendeurService();
            return JsonConvert.SerializeObject(s.GetAll());
        }
    }


}
