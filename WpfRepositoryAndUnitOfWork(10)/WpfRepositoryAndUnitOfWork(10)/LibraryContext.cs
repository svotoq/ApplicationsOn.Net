﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRepositoryAndUnitOfWork_10_
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection")
        { }
        public DbSet<Book> Books { get; set; }
    }
}
