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
    public class RechargingCouponService:Service<recharging_coupon>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public RechargingCouponService() : base(uow)
        {

        }

        public recharging_coupon getByCode(string code)
        {
            List<recharging_coupon> l = GetAll().Where(c => c.code.Equals(code)).ToList();
            if (l.Count == 0)
                return null;
            return l.First();
        }

        
    }
}
