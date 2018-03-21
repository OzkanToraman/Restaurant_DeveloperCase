using Restaurant_DeveloperCase.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.Repository.UOW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        IRepository<T> GetRepo<T>() where T : class, new();
        void Dispose(bool disposing);
    }

}
