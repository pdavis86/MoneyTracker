using System;
using System.Collections.Generic;

namespace MoneyTracker.Core
{
    public interface IRepository<T> : IDisposable
    {
        void Create(T item);
        IEnumerable<T> Retrieve();
        T Retrieve(int id);
        void Update(T item);
        void Delete(int id);
        void SaveChanges();
    }
}
