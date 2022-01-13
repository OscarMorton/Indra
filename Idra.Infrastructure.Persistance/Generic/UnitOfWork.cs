using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Infrastructure.Persistance;

namespace CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        Context Context { get; }

        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public Context Context { get; }

        public UnitOfWork(Context context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}