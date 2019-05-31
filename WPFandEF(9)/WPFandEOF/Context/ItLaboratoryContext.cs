using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFandEOF.Model;

namespace WPFandEOF.Context
{
    public class ItLaboratoryContext : DbContext
    {
        public ItLaboratoryContext() : base("ItLaboratory") { }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Computer> Computers { get; set; }
    }
}
