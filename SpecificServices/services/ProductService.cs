using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domaine.entities;
using Mehdi.data.Infrastructure;
using Mehdi.Services;

namespace SpecificServices.services
{
    public class ProductService:Service<product>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ProductService() : base(uow)
        {

        }

        
    }
}
