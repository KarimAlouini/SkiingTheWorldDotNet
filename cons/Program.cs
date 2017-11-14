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

namespace cons
{
    class Program
    {
        public string BaseUrl = "http://localhost:18080/SkiWorld-web/v0/secured/coupons";
        static void Main(string[] args)
        {
         
            SWModel m = new SWModel();
            Console.WriteLine(m.access_tokens.Count());
            Console.ReadKey();

        }
    }
}
