using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using SkiingTheWorld_PI.Domaine.Entities;
using SpecificServices.services;

namespace web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            SousCategorieService sousCategorieService = new SousCategorieService();
            return View(sousCategorieService.GetAll());
        }

        public ActionResult SubCategory(int cat,int scat)
        {
            ProductService s = new ProductService();
            SousCategorieService sousCategorieService = new SousCategorieService();

            ViewBag.sCats = sousCategorieService.GetAll().Where(sc => ((int)sc.MarquecategorieProd) == cat).ToList();

            List<product> p = new List<product>();

            foreach (product product in s.GetAll())
            {
                
                
                if (product.sousCategorieProd.Equals(sousCategorieService.GetById(scat)) &&
                   ((int) product.sousCategorieProd.MarquecategorieProd) == cat)
                {
                    p.Add(product);
                }
            }

            return View(p);
        }

        public ActionResult Category(int cat)
        {


            SousCategorieService sousCategorieService = new SousCategorieService();
            ViewBag.sCats = sousCategorieService.GetAll().Where(sc=> ((int)sc.MarquecategorieProd) == cat).ToList();

            ProductService s = new ProductService();

            List<product> p = new List<product>();

            foreach (product product in s.GetAll())
            {

                if (
                    ((int)product.sousCategorieProd.MarquecategorieProd) == cat)
                {
                    p.Add(product);
                }
            }
            return View(p);
        }

        public ActionResult Product(int idProdcut)
        {
            return View();
        }

        
    }
}