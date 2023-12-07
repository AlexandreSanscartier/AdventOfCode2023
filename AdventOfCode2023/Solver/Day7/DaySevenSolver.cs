using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.CamelCards;
using AdventOfCode2023.Services.Interfaces;
using AdventOfCode2023.Services;
using System.Net.Http.Headers;

namespace AdventOfCode2023.Solver.day7
{
	public class DaySevenSolver : BaseSolver<List<CamelCardMatch>>
	{
		public DaySevenSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDaySevenInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

        public override int Day => 7;

		public override string SolvePartOne(List<CamelCardMatch> input)
		{
			var camelCardHandEvaluator = new CamelCardHandEvaluator();
			var bettingRanked = new List<int>();
			long bettingResult = 0l;
			foreach(var match in input)
			{
                match.CamelCardHandType = camelCardHandEvaluator.Evaluate(match.CamelCardHand);
			}

			var orderedList = input.OrderByDescending(x => x.CamelCardHandType)
					.ThenBy(x => x.CamelCardHand.Cards.First())
					.ThenBy(x => x.CamelCardHand.Cards.Skip(1).First())
					.ThenBy(x => x.CamelCardHand.Cards.Skip(2).First())
					.ThenBy(x => x.CamelCardHand.Cards.Skip(3).First())
					.ThenBy(x => x.CamelCardHand.Cards.Skip(4).First())
					.ToList();

			for(int i = 0; i < orderedList.Count(); i++)
			{
                bettingResult += orderedList[i].Bet * (i + 1);
            }
			return bettingResult.ToString();
        }

		public override string SolvePartTwo(List<CamelCardMatch> input)
		{
            // 246721183 TOO LOW
            var camelCardHandEvaluator = new CamelCardJokerHandEvaluator();
            var bettingRanked = new List<int>();
            long bettingResult = 0l;
            foreach (var match in input)
            {
                match.CamelCardHandType = camelCardHandEvaluator.Evaluate(match.CamelCardHand);
            }

            var orderedList = input.OrderByDescending(x => x.CamelCardHandType)
                    .ThenBy(x => x.CamelCardHand.Cards.First())
                    .ThenBy(x => x.CamelCardHand.Cards.Skip(1).First())
                    .ThenBy(x => x.CamelCardHand.Cards.Skip(2).First())
                    .ThenBy(x => x.CamelCardHand.Cards.Skip(3).First())
                    .ThenBy(x => x.CamelCardHand.Cards.Skip(4).First())
                    .ToList();

            for (int i = 0; i < orderedList.Count(); i++)
            {
                bettingResult += orderedList[i].Bet * (i + 1);
            }
            return bettingResult.ToString();
        }
	}
}
