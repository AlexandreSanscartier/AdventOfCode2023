using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTest.Library.Interfaces
{
    public interface ISolverTheoryTests : ISolverTests
    {
        void SampleInput_ParsersCorrectly(string input, string expectedResult);

        Task SamplePartOneInput_ProducesCorrectResultForPartOne(string input, string expectedResult);

        Task SampleInput_ProducesCorrectResultForPartTwo(string input, string expectedResult);
    }
}
