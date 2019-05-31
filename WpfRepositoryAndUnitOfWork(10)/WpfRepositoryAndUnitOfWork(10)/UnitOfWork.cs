using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRepositoryAndUnitOfWork_10_
{
    public class UnitOfWork : IDisposable
    {
        private LibraryContext db;
        private SqlBookRepository sqlBookRepository;
        public UnitOfWork()
        {
            db = new LibraryContext();
        }

        public SqlBookRepository Book
        {
            get
            {
                if(sqlBookRepository==null)
                {
                    sqlBookRepository = new SqlBookRepository();
                }
                return sqlBookRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
