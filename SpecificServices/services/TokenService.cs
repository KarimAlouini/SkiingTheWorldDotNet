using domaine.entities;
using Mehdi.data.Infrastructure;
using Mehdi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificServices
{
  public  class TokenService : Service<access_tokens>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public TokenService() : base(uow)
        {

        }

      

         // specific methods
    }
}
