using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;
using System.Linq;
using AdventOfCode2023.ExtensionMethods;

namespace AdventOfCode2023.Solver.day4
{
	public class DayFourSolver : BaseSolver<List<ScratchCard>>
	{
		public DayFourSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayFourInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 4;

		public override string SolvePartOne(List<ScratchCard> input)
		{
			var totalPoints = 0;
			foreach (var scratchCard in input) {
				var winningNumbers = scratchCard.NumbersYouHave.Intersect(scratchCard.WinningNumbers);
				var points = (int)Math.Pow(2, winningNumbers.Count() - 1);
				totalPoints += points;
            }
            return totalPoints.ToString();
		}

		public override string SolvePartTwo(List<ScratchCard> input)
		{
			var cardCopies = new int[input.Count()];
			cardCopies.Populate(1);
			var currentIndex = 0;
            foreach (var scratchCard in input)
            {
                var winningNumbers = scratchCard.NumbersYouHave.Intersect(scratchCard.WinningNumbers);
				var copyCardsWon = winningNumbers.Count();
                for (int i = 0; i < copyCardsWon; i++) {
					cardCopies[currentIndex + i + 1] += (1 * cardCopies[currentIndex]);
				}
				currentIndex++;
            }

			var sum = cardCopies.Sum();
			return sum.ToString();
        }
	}
}
