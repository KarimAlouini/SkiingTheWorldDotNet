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
  public  class RevendeurService : Service<seller>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public RevendeurService() : base(uow)
        {

        }



         // specific methods
    }
}
