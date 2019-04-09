using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNo2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Combi combi = new Combi(new string[]{"A","B","C","D"});
            int buf = 0;
            for(int i=0; i<16;i++)
            {
                Console.WriteLine(buf & 0x1);
                    buf >>= 1;
            }
        }
    }
}
