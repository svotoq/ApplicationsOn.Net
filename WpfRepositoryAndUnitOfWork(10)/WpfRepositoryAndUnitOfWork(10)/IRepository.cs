using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRepositoryAndUnitOfWork_10_
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetBookList();
        T GetBook(int id);
        void Add(T item);
        void Update(T item);
        void Remove(int id);
    }
}
