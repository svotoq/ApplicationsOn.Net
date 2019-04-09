using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNo2_1
{
    public class Combi
    {
        public string[] Array { get; set; }

        public string this[int index] { get => Array[index]; set => Array[index] = value; }

        public Combi(string[] array)
        {
            Array = array;
        }

        public string[] Generate()
        {
            string[] result = new string[Array.Length * Array.Length];
            uint[] indexes = SetIndexes();
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Array[indexes[i]];
            }
            return result;
        }

        private uint[] SetIndexes()
        {
            uint[] indexes = new uint[Array.Length * Array.Length];
            uint index = 0;
            byte buf = 0;
            for (uint i = 0; i < Array.Length; i++)
            {
                if ((buf & 0x1)==0) indexes[index++] = i;
                buf >>= 1;
            }
            return indexes;
        }

        public string GetNext(int index)
        {
            string result = "";
            if (index < Array.Length - 1)
            {
                result = Array[index];
            }
            else
            {

            }
            return result;
        }
    }
}
