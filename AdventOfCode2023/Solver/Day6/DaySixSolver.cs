using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;
using AdventOfCode2023.ExtensionMethods;

namespace AdventOfCode2023.Solver.day6
{
	public class DaySixSolver : BaseSolver<List<Race>>
	{
		public DaySixSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDaySixInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 6;


		public override string SolvePartOne(List<Race> input)
		{
			List<int> numberOfWaysToWinList = new();
			int numberOfWaysToWin = 0;
			foreach(var race in input)
			{
				for(int i = 0; i < race.Time; i++)
				{
					var timeLeft = race.Time - i;
					if((timeLeft * i) - race.Distance > 0)
					{
						numberOfWaysToWin++;
                    }
				}
				numberOfWaysToWinList.Add(numberOfWaysToWin);
				numberOfWaysToWin = 0;
            }
			return numberOfWaysToWinList.Multiply().ToString();
        }

		public override string SolvePartTwo(List<Race> input)
		{
			return this.SolvePartOne(input);
        }
	}
}
