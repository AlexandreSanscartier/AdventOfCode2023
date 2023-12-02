using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDayGenerator.Models.Interfaces
{
    public interface ISolverCreationModel
    {
        Day Day { get; set; }

        string InterfaceOrClassName { get; set; }

        string InputNamespace { get; set; }

        string BaseNamespace { get; set; }

        string DayDirectory { get; set; }

        string DayTestDirectory { get; set; }

        string InputParserInterfaceName { get; }

        string InputParserClassName { get; }

        string SolverClassName { get; }
    }
}
