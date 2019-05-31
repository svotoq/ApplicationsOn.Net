using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFandEOF.Model
{
    public class Computer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int RamSize { get; set; }
        public int? ProcessorId { get; set; }
        public Processor Processor { get; set; }

 
    }
}
