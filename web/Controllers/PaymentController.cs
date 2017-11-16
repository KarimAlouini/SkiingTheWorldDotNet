using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using domaine.entities;
using web.App_Start;

namespace web.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost]
        public String Index(string month, string year, string cvc, string number, string amount)
        {

          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.BANK);
            request.Method = "POST";
          
            request.Headers.Add("month",month.ToString());
            request.Headers.Add("year", year.ToString());
            request.Headers.Add("cvc", cvc.ToString());
            request.Headers.Add("number", number.ToString());
            request.Headers.Add("amount",Session["total"].ToString());


            using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    string responseText = reader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine("here");
                    return responseText;

                }
           
        }
    }
}