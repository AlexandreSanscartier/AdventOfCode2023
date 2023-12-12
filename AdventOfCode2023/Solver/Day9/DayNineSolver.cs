using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;
using System.Linq;

namespace AdventOfCode2023.Solver.day9
{
	public class DayNineSolver : BaseSolver<List<OasisReport>>
	{
		public DayNineSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayNineInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 9;

		public override string SolvePartOne(List<OasisReport> input)
		{
			List<long> nextValues = new();
			foreach(var report in input)
			{
                var seqeuences = new List<List<long>>
                {
                    report.ValueHistory
                };
                var results = report.ValueHistory;
                do
				{
					results = FindPattern(results);
                    seqeuences.Add(results);
                } while (!results.All(x => x == 0));

				nextValues.Add(FindNextValue(seqeuences));
            }
			return nextValues.Sum().ToString();
		}

		private long FindNextValue(List<List<long>> sequences)
		{
			for(int i = sequences.Count() - 1; i > 0; i--) {
				var pattern = sequences[i].Last() + sequences[i - 1].Skip(sequences[i - 1].Count() - 1).First();
				sequences[i - 1].Add(pattern);
			}
			return sequences.First().Last();
		}

		private List<long> FindPattern(List<long> pattern)
		{
			var sequence = new List<long>();
            for (var i = 0; i < pattern.Count() - 1; i++)
            {
                var patternNumber = pattern[i + 1] - pattern[i];
                sequence.Add(patternNumber);
            }
			return sequence;
        }

		public override string SolvePartTwo(List<OasisReport> input)
		{
            List<long> nextValues = new();
            foreach (var report in input)
            {
                var seqeuences = new List<List<long>>
                {
                    report.ValueHistory
                };
                var results = report.ValueHistory;
                do
                {
                    results = FindPattern(results);
                    seqeuences.Add(results);
                } while (!results.All(x => x == 0));

                nextValues.Add(FindPreviousValue(seqeuences));
            }
            return nextValues.Sum().ToString();
        }

        private long FindPreviousValue(List<List<long>> sequences)
        {
            for (int i = sequences.Count() - 1; i > 0; i--)
            {
                var pattern = sequences[i - 1].First() - sequences[i].First();
                sequences[i - 1].Insert(0, pattern);
            }
            return sequences.First().First();
        }
    }
}
