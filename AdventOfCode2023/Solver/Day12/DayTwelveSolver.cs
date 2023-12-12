using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Solver.day12
{
	public class DayTwelveSolver : BaseSolver<List<SpringConditionRecord>>
	{
		public DayTwelveSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayTwelveInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 12;

		public override string SolvePartOne(List<SpringConditionRecord> input)
		{
			int result = 0;
			foreach (var springConditionRecord in input)
			{
				result += FindAllDifferentArrangements(springConditionRecord);
            }
			return result.ToString();
		}

		private int FindAllDifferentArrangements(SpringConditionRecord springConditionRecord)
		{
			var pattern = springConditionRecord.Pattern;
			var sizeOfGroups = springConditionRecord.SizeOfContiguousGroups;
			var patternToFill = string.Empty;
			foreach(var sizeOfGroup in sizeOfGroups)
			{
				patternToFill += RepeatTimes("#", sizeOfGroup) + ".";
			}
			patternToFill = patternToFill.Substring(0, patternToFill.Length - 1);

			return 0;

        }

		private string RepeatTimes(string text, int amount)
		{
			var returnText = string.Empty;
			for (int i = 0; i < amount; i++)
			{
				returnText += text;
            }
			return returnText;
		}

		private bool IsValidArrangement(string arrangement, List<int> sizeOfGroups)
		{
			var arrangementParts = arrangement.Split('.').Where(x => !string.IsNullOrEmpty(x));
			return sizeOfGroups.Count() == arrangementParts.Count() && arrangementParts.All(x => sizeOfGroups.Contains(x.Length));
		}

		public override string SolvePartTwo(List<SpringConditionRecord> input)
		{
			// Insert code here that solves part two of the problem
			throw new MissingMethodException();
		}
	}
}
