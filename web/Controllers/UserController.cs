using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using Newtonsoft.Json;
using SpecificServices;
using SpecificServices.services;
using web.Models;
using web.Util;

namespace web.Controllers
{
    public class UserController : Controller
    {
        public string BaseUrl = "http://localhost:18080/SkiWorld-web/v0/users";
        // GET: User
        public ActionResult Login()
        {
            return View();

        }

       

        [HttpPost]
        public ActionResult Login(string login,string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);
            request.Method = "POST";
            request.Headers.Add("login",login);
            request.Headers.Add("password",password);
            
            using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                string responseText = reader.ReadToEnd();
                LoginResponse response = JsonConvert.DeserializeObject<LoginResponse>(responseText);
                if (response.Code == 0)
                {
                    Session["user"] = response.Token.user;
                    Session["token"] = response.Token.value;
                    System.Diagnostics.Debug.WriteLine(response.Token.value);
                    return RedirectToAction("Index", "Home");
                }

                else
                {


                    return RedirectToAction("Login",new {message=response.Message});
                }    


            }

            

        }
    }
}