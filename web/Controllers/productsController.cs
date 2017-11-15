using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using web.Util;

namespace web.Controllers
{
    public class productsController : Controller
    {
        private SWModel db = new SWModel();

        // GET: products
        public ActionResult Index()
        {
            var product = db.product.Include(p => p.sousCategorieProd);
            return View(product.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.sousCategorieProdId = new SelectList(db.souscategories, "Id", "Libelle");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reference,Description,Marque,Modele,Name,Photo,Quantity,Color,Size,price,sousCategorieProdId,userId")] product product,HttpPostedFileBase File)
        {

            if (ModelState.IsValid)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.0.100:18080/SkiWorld-web/v0/badword");
                request.Method = "POST";
                request.Headers.Add("text", product.Description);
                using (var reader =new StreamReader(request.GetResponse().GetResponseStream(),Encoding.UTF8))
                {
                    string responsetext = reader.ReadToEnd();
                    MessageResponse msg = JsonConvert.DeserializeObject<MessageResponse>(responsetext);
                    if (msg.Code == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("zis1");
                        if (File.ContentLength > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("zis2");
                            string _FileName = Path.GetFileName(new Random().Next().ToString() + File.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/Upload"), _FileName);

                            File.SaveAs(path);
                            product.Photo= _FileName;
                        }

                        db.product.Add(product);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("zis");
                        
                        List<string> badworsList =JsonConvert.DeserializeObject <List<string>>(msg.Message.ToString());
                     

                        return RedirectToAction("Create",new {msg=JsonConvert.SerializeObject(badworsList)});
                    }
                }

                
            }

            ViewBag.sousCategorieProdId = new SelectList(db.souscategories, "Id", "Libelle", product.sousCategorieProdId);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.sousCategorieProdId = new SelectList(db.souscategories, "Id", "Libelle", product.sousCategorieProdId);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reference,MarquecategorieProd,Description,Marque,Modele,Name,Photo,Quantity,Color,Size,price,sousCategorieProdId,userId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sousCategorieProdId = new SelectList(db.souscategories, "Id", "Libelle", product.sousCategorieProdId);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.product.Find(id);
            db.product.Remove(product);
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
