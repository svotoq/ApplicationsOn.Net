using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRepositoryAndUnitOfWork_10_
{
    public class SqlBookRepository : IRepository<Book>
    {
        private LibraryContext db;
        public SqlBookRepository()
        {
            db = new LibraryContext();
        }
        public Book GetBook(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetBookList()
        {
            return db.Books;
        }

        public void Add(Book item)
        {
            db.Books.Add(item);
        }
        
        public void Remove(int id)
        {
            Book book = db.Books.Find(id);
            if(book!=null)
            {
                db.Books.Remove(book);
            }
        }


        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
    }
}
