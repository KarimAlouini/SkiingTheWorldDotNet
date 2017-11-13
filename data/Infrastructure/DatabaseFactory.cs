using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domaine.entities;


namespace Mehdi.data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        // factory va fournir le context
        private SWModel dataContext;
        /// <summary>
        /// propriéte full
        /// </summary>
        public SWModel DataContext { get { return dataContext; } }
        public DatabaseFactory()
        {
            dataContext = new SWModel();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
