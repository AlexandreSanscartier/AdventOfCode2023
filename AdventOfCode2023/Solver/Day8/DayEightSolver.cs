using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Maps;

namespace AdventOfCode2023.Solver.day8
{
	public class DayEightSolver : BaseSolver<MapInstruction>
	{
		public DayEightSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayEightInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 8;

		public override string SolvePartOne(MapInstruction input)
		{
			// Insert code here that solves part one of the problem
			throw new MissingMethodException();
		}

		public override string SolvePartTwo(MapInstruction input)
		{
			// Insert code here that solves part two of the problem
			throw new MissingMethodException();
		}
	}
}
