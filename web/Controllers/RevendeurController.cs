using domaine.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpecificServices;
using web.Models;

namespace web.Controllers
{
    public class RevendeurController : Controller
    {
        RevendeurService rvs = new RevendeurService();
        // GET: Revendeur
        public ActionResult Index()
        {
            var sellers = rvs.GetAll();
            List<RevendeurModel> lM = new List<RevendeurModel>();
            System.Diagnostics.Debug.WriteLine("count "+sellers.ToList().Count);
            foreach (var item in sellers)
            {
                lM.Add(new RevendeurModel()
                {
                   tel = item.phoneNumber,
                    Id = item.id,
                    Name = item.name,
                    Email = item.email,
                    Latitude = item.latitude,
                    Longitude = item.longitude
                   
                   

                });

              
            }




            return View(lM);
        }

        // GET: Revendeur/Details/5
        public ActionResult Details(int id)
        {
          seller pe = rvs.GetById(id);

            RevendeurModel pm = new RevendeurModel()
            {
                tel = pe.phoneNumber,
                Longitude =pe.longitude ,
                Latitude = pe.latitude,
               Name = pe.name,
               Email = pe.email,
               Id = pe.id




            };
            return View(pm);
        }

        // GET: Revendeur/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Revendeur/Create
        [HttpPost]
        public ActionResult Create(RevendeurModel collection)
        {

            seller s1 = new seller
            {

                name = collection.Name,
                phoneNumber = collection.tel,
                email = collection.Email,
                latitude = collection.Latitude,
                longitude = collection.Longitude
            };





              

            rvs.Add(s1);
            rvs.Commit();

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
