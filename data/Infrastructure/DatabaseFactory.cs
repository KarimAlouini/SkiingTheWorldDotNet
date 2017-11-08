using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mehdi.data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        // factory va fournir le context
        private Context dataContext;
        /// <summary>
        /// propriéte full
        /// </summary>
        public Context DataContext { get { return dataContext; } }
        public DatabaseFactory()
        {
            dataContext = new Context();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
