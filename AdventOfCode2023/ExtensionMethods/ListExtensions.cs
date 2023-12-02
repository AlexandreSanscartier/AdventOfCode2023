using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.ExtensionMethods
{
    public static class ListExtensions
    {
        public static int Multiply(this List<int> list)
        {
            var product = 1;
            foreach(var item in list)
            {
                product *= item;
            }
            return product;
        }
    }
}
