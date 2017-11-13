using System;
using System.Collections.Generic;
using System.IO;

using System.Net;

using System.Text;

using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using web.Util;

namespace web.Controllers
{
    public class RecharginCouponsController : Controller
    {
        public string BaseUrl = "http://localhost:18080/SkiWorld-web/v0/secured/coupons";

        // GET: RecharginCoupons
        public ActionResult Index()
        {
            List<recharging_coupon> coupons = new List<recharging_coupon>();
           

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);
            request.Method = "GET";
            request.Headers.Add("Authorization", "xa");
            using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                string responseText = reader.ReadToEnd();
                coupons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<recharging_coupon>>(responseText);

            }




            return View(coupons);


        }

        // GET: RecharginCoupons/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecharginCoupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecharginCoupons/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RecharginCoupons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecharginCoupons/Edit/5
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

        // GET: RecharginCoupons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecharginCoupons/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Generate(int count, double amount)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);
            request.Method = "POST";
            request.Headers.Add("Authorization", "xa");
            request.Headers.Add("count",count.ToString());
            request.Headers.Add("amount",amount.ToString());
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return RedirectToAction("Index");
            }
           
            
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    string responseText = reader.ReadToEnd();
                    MessageResponse res = JsonConvert.DeserializeObject<MessageResponse>(responseText);


                }
            
            
                
            


            return RedirectToAction("Index");
        }

        public ActionResult Generate()
        {
            return View();
        }
    }

    
}
