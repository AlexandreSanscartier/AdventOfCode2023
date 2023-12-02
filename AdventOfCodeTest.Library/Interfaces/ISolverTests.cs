using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTest.Library.Interfaces
{
    public interface ISolverTests
    {
        int Day { get; }

        Task PartOne_ProducesCorrectResult();

        Task PartTwo_ProducesCorrectResult();
    }
}
