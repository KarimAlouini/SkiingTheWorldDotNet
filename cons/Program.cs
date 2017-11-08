using data;
using domaine.entities;
using SpecificServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cons
{
    class Program
    {
        static void Main(string[] args)
        {
            SWModel m = new SWModel();
            m.seller.Add(new seller{ name="nadim"});
            m.SaveChanges();
            
           
            Console.ReadKey();
           
        }
    }
}
