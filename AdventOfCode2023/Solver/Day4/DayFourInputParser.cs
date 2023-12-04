using AdventOfCode2023.Models;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day4

{
	public class DayFourInputParser : BaseInputParser<List<ScratchCard>>, IDayFourInputParser
	{
		public override List<ScratchCard> Parse(string input)
		{
			var inputParts = input.Split('\n');
			var scratchCards = new List<ScratchCard>();
			foreach(var inputPart in inputParts)
			{
				var scratchCardNumbers = inputPart.Split(':')[1];
				var winningNumbers = scratchCardNumbers.Split('|')[0].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Trim())).ToList();
                var numbersYouHave = scratchCardNumbers.Split('|')[1].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Trim())).ToList();
				scratchCards.Add(new ScratchCard(winningNumbers, numbersYouHave));
            }
			return scratchCards;
		}
	}
}
