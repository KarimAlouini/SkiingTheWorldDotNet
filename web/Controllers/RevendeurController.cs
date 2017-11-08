using domaine.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class RevendeurController : Controller
    {
        // GET: Revendeur
        public ActionResult Index()
        {

            List<seller> model = new List<seller>();
            using(SWModel swM = new SWModel())
            {
                model = swM.seller.ToList<seller>();
            }
            
            return View(model);
        }

        // GET: Revendeur/Details/5
        public ActionResult Details(int id)
        {
            seller model = new seller();
            using (SWModel swM = new SWModel())
            {
                model = swM.seller.Where(s => s.id == id).First();
            }

            return View(model);
        }

        // GET: Revendeur/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Revendeur/Create
        [HttpPost]
        public ActionResult Create(seller collection)
        {
            
                // TODO: Add insert logic here
                SWModel m = new SWModel();
                m.seller.Add(collection);
                m.SaveChanges();

                return RedirectToAction("Index");
            
            
        }

        // GET: Revendeur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Revendeur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Revendeur/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Revendeur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (SWModel swM = new SWModel())
                {
                    swM.seller.Remove(swM.seller.Where(s => s.id == id).First());
                    swM.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
