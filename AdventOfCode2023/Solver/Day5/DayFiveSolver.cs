using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Gardens;

namespace AdventOfCode2023.Solver.day5
{
	public class DayFiveSolver : BaseSolver<GardenAlmanac>
	{
		public DayFiveSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayFiveInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 5;

		public override string SolvePartOne(GardenAlmanac input)
		{
			// Insert code here that solves part one of the problem
			throw new MissingMethodException();
		}

		public override string SolvePartTwo(GardenAlmanac input)
		{
			// Insert code here that solves part two of the problem
			throw new MissingMethodException();
		}
	}
}
