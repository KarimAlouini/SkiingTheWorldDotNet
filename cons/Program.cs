using data;
using domaine.entities;
using SpecificServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpecificServices.services;

namespace cons
{
    class Program
    {
        public string BaseUrl = "http://localhost:18080/SkiWorld-web/v0/secured/coupons";
        static void Main(string[] args)
        {
         
            SousCategorieService sc = new SousCategorieService();
            Console.WriteLine(sc.GetAll().Count());
            Console.ReadKey();

           
        }
    }
}
