using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFandEOF.Model
{
   public class Processor
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxFrequency { get; set; }
        public override string ToString()
        {
            return Model + ' ' + MaxFrequency + "MHz";
        }
    }
}
