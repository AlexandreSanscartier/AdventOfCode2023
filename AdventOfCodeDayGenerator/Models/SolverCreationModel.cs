using AdventOfCodeDayGenerator.ExtensionMethods;
using AdventOfCodeDayGenerator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDayGenerator.Models
{
    public class SolverCreationModel : ISolverCreationModel
    {
        public Day Day { get; set; }
        public string InterfaceOrClassName { get; set; }
        public string InputNamespace { get; set; }
        public string DayDirectory { get; set; }
        public string DayTestDirectory { get; set; }
        public string BaseNamespace { get; set; }

        public string InputParserInterfaceName => $"IDay{Day.ToStringDay()}InputParser";

        public string InputParserClassName => $"Day{Day.ToStringDay()}InputParser";

        public string SolverClassName => $"Day{Day.ToStringDay()}Solver";
    }
}
