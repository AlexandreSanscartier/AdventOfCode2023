using AdventOfCode2023.Models;
using AdventOfCode2023.Models.Interfaces;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day9

{
	public class DayNineInputParser : BaseInputParser<List<OasisReport>>, IDayNineInputParser
	{
		public override List<OasisReport> Parse(string input)
		{
            var inputParts = input.Split('\n');
            var oasisReports = new List<OasisReport>();

            foreach (var inputPart in inputParts)
            {
                var oasisReport = new OasisReport();
                inputPart.Split(' ').ToList().ForEach(x => oasisReport.ValueHistory.Add(long.Parse(x)));
                oasisReports.Add(oasisReport);
            }
            return oasisReports;
        }
	}
}
