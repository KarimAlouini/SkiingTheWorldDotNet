using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using SpecificServices.services;
using web.Util;

namespace web.Controllers
{
    public class CartController : Controller
    {
        [HttpPost]
        public string Add(int id)
        {
            ProductService productService = new ProductService();
            product product = productService.GetById(id);
            if (product != null)
            {


                Dictionary<product, int> cart = (Dictionary<product, int>) Session["cart"];
                if (cart == null)
                    cart = new Dictionary<product, int>();

                if (cart.ContainsKey(product))
                {
                    cart[product]++;
                }

                else
                {
                    cart[product] = 1;
                }

                Session["cart"] = cart;

              
                 
              
               
                
                
                return JsonConvert.SerializeObject(new MessageResponse {Code=0,Message = "Product added to cart" });
                //return JsonConvert.SerializeObject(cart);
            }

            return JsonConvert.SerializeObject(new MessageResponse {Code = 1,Message = "Couldn't add product to card"});

        }

        public string Count()
        {
            Dictionary<product,int> cart = (Dictionary<product, int>) Session["cart"];
            if (cart == null)
            {
                return "0";
            }
            else
            {
                return cart.Count.ToString();
            }
        }

        public ActionResult Content()
        {
            Dictionary<product, int> cart = (Dictionary<product, int>)Session["cart"];
            ViewBag.cart = cart;
            return PartialView();
        }
    }

  
}