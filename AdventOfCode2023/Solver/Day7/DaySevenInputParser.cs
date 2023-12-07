using AdventOfCode2023.Models.CamelCards;
using AdventOfCode2023.Services.Interfaces;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day7

{
	public class DaySevenInputParser : BaseInputParser<List<CamelCardMatch>>, IDaySevenInputParser
	{
        public override List<CamelCardMatch> Parse(string input)
		{
			var inputParts = input.Split('\n');
			var camelCardMatches = new List<CamelCardMatch>();
			foreach(var inputPart in inputParts)
			{
				var cardMatchParts = inputPart.Split(' ');
				var cardsInHand = new List<int>();
				cardMatchParts.First().ToList().ForEach(x => cardsInHand.Add(replaceCharWithNumberRepresentation(x)));

				var bet = int.Parse(cardMatchParts.Last());
				var camelCardMatch = new CamelCardMatch()
				{
					CamelCardHand = new CamelCardHand(cardsInHand),
					Bet = bet
				};
                camelCardMatches.Add(camelCardMatch);
            }
			return camelCardMatches;
		}

        public override List<CamelCardMatch> ParseProblemTwoInput(string input)
        {
            var inputParts = input.Split('\n');
            var camelCardMatches = new List<CamelCardMatch>();
            foreach (var inputPart in inputParts)
            {
                var cardMatchParts = inputPart.Split(' ');
                var cardsInHand = new List<int>();
                cardMatchParts.First().ToList().ForEach(x => cardsInHand.Add(replaceCharWithNumberRepresentationForPartTwo(x)));

                var bet = int.Parse(cardMatchParts.Last());
                var camelCardMatch = new CamelCardMatch()
                {
                    CamelCardHand = new CamelCardHand(cardsInHand),
                    Bet = bet
                };
                camelCardMatches.Add(camelCardMatch);
            }
            return camelCardMatches;
        }

        public int replaceCharWithNumberRepresentationForPartTwo(char card)
        {
            if (card.Equals('T')) return 10;
            if (card.Equals('J')) return 1;
            if (card.Equals('Q')) return 12;
            if (card.Equals('K')) return 13;
            if (card.Equals('A')) return 14;
            return int.Parse($"{card}");
        }

        public int replaceCharWithNumberRepresentation(char card)
		{
			if (card.Equals('T')) return 10;
			if (card.Equals('J')) return 11;
			if (card.Equals('Q')) return 12;
			if (card.Equals('K')) return 13;
			if (card.Equals('A')) return 14;
			return int.Parse($"{card}");
        }
	}
}
