using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRepositoryAndUnitOfWork_10_
{
    public class MainWindowViewModel
    {
        UnitOfWork unitOfWork;
        public List<Book> Books { get; }
        public MainWindowViewModel()
        {
            unitOfWork = new UnitOfWork();
            if (unitOfWork.Book.GetBookList().Count() == 0)
            {
                unitOfWork.Book.Add(new Book { Author = "Станислав", Name = "Приключения стасяна", Price = 999 });
                unitOfWork.Book.Add(new Book { Author = "Артем", Name = "Как быть если...", Price = 315 });
                unitOfWork.Book.Add(new Book { Author = "Игрек", Name = "Y-Corporation история успеха", Price = 752 });
                unitOfWork.Save();
            }
            Books = unitOfWork.Book.GetBookList().ToList();
        }
    }
}
