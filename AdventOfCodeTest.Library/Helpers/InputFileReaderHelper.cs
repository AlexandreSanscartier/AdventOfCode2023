using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTest.Library.Helpers
{
    public static class InputFileReaderHelper
    {
        public static string ReadFile(int day)
        {
            return File.ReadAllText(Path.Combine("Inputs", $"InputDay{day}.txt")).TrimEnd();
        }
    }
}
