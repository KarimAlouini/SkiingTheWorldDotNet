using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
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

        [Route("SubCategory")]
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

        [Route("Category")]
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

        public ActionResult Product(int id)
        {
            ProductService ps = new ProductService();
            product p = ps.GetById(id);
            if (p == null)
                return new HttpNotFoundResult();
            List<product> others = new List<product>();



            do
            {
                int index = new Random().Next(1, ps.GetAll().Count());
                System.Diagnostics.Debug.WriteLine(ps.GetAll().Count());
                product toAdd = ps.GetAll().ToList()[index];
                if (others.Where(pro => pro.Reference == toAdd.Reference && pro.Reference != id).Count() == 0)
                {
                    others.Add(toAdd);
                }
               
            } while (others.Count != 3);
            

            ViewBag.others = others;
           
            return View(p);
        }

        
    }
}