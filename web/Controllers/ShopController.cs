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

        public ActionResult SubCategory(string cat,string scat)
        {
            ProductService s = new ProductService();
            SousCategorieService sousCategorieService = new SousCategorieService();

            

            List<product> p = new List<product>();

            foreach (product product in s.GetAll())
            {
                souscategorie.CategorieEnum e = (souscategorie.CategorieEnum)Enum.Parse(typeof(souscategorie.CategorieEnum), cat, true);
                if (product.sousCategorieProd.Libelle.Equals(scat) &&
                    product.sousCategorieProd.MarquecategorieProd.Equals(e))
                {
                    p.Add(product);
                }
            }

            return View(p);
        }

        
    }
}