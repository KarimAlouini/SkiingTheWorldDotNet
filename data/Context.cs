using data.CustomConvention;
using domaine.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Context : DbContext
    {

        public Context() : base("name=SkiWorldDataSource")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTimeConvention());
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);

        }


    }
}