using System;
using System.Collections.Generic;
using System.IO;

using System.Net;

using System.Text;

using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using SpecificServices.services;
using web.App_Start;
using web.Util;

namespace web.Controllers
{
    public class RecharginCouponsController : Controller
    {
        public string BaseUrl = Config.URL+"secured/coupons";
        private user currentUser;

        // GET: RecharginCoupons
        public ActionResult Index()
        {
            List<recharging_coupon> coupons = new List<recharging_coupon>();
           

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);
            request.Method = "GET";
            currentUser = Session["user"] as user;
            request.Headers.Add("Authorization", Session["token"] as string);
           
            try
            {
               
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    string responseText = reader.ReadToEnd();
                    coupons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<recharging_coupon>>(responseText);
                    System.Diagnostics.Debug.WriteLine(coupons.Count);

                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error403", "Misc");
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
            request.Headers.Add("Authorization", Session["token"] as string);
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

        public ActionResult Delete(int id)
        {
            RechargingCouponService s = new RechargingCouponService();
            recharging_coupon c = s.GetById(id);
            if (c == null)
                return new HttpNotFoundResult();
            s.Delete(s.GetById(id));
            s.Commit();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Pay(string code)
        {

            RechargingCouponService s = new RechargingCouponService();
            recharging_coupon c = s.getByCode(code);

            System.Diagnostics.Debug.WriteLine(code);
            if (c != null)
            {
                if (c.isUsed)
                {
                    ViewBag.Code = 1;
                    ViewBag.Message = "The coupon is used !";
                }
                else
                {
                    user u = (user) Session["user"];
                    if (u != null)
                    {
                        c.isUsed = true;
                        s.Update(c);
                        s.Commit();
                        UserService us = new UserService();
                        System.Diagnostics.Debug.WriteLine(code);

                        u = us.GetById(u.id);
                        u.balance += (double)c.amount;
                        us.Update(u);
                        us.Commit();
                        ViewBag.Code = 0;
                        ViewBag.Message = "Balance recharged !";
                    }
                }
            }
            else
            {
                ViewBag.Code = 1;
                ViewBag.Message = "The coupon is not valid !";
            }

            if (ViewBag.code != 0)
            {
                return RedirectToAction("Recharge", new {message = ViewBag.Message});
            }


            return RedirectToAction("Index", "Home");
        }

        public ActionResult Recharge()
        {
            return View();
        }
    }

    
}
