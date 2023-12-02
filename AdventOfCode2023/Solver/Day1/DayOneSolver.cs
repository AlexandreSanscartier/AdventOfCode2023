using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;

namespace AdventOfCode2023.Solver.day1
{
	public class DayOneSolver : BaseSolver<List<int>>
	{
		public DayOneSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayOneInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 1;

		public override string SolvePartOne(List<int> input)
		{
			var result = input.Sum();
			return result.ToString();
		}

		public override string SolvePartTwo(List<int> input)
		{
            var result = input.Sum();
            return result.ToString();
        }
	}
}
