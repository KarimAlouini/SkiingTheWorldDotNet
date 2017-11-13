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
        public ActionResult Login(LoginModel model)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);
            request.Method = "POST";
            request.Headers.Add("login",model.Login);
            request.Headers.Add("password",model.Password);
            using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                string responseText = reader.ReadToEnd();
                MessageResponse response = JsonConvert.DeserializeObject<MessageResponse>(responseText);


            }

            return View();

        }
    }
}