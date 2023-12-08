using AdventOfCode2023.Models.CamelCards.Interfaces;
using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.CamelCards
{
    public class CamelCardMatch : ICamelCardMatch
    {
        public ICamelCardHand CamelCardHand { get; set; }
        public int Bet { get; set; }

        public CamelCardHandType CamelCardHandType { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CamelCardMatch match &&
                   CamelCardHand.Cards.Count() == match.CamelCardHand.Cards.Count() &&
                   CamelCardHand.Cards.All(x => match.CamelCardHand.Cards.Contains(x)) &&
                   Bet == match.Bet;
        }

        public override string ToString()
        {
            return $"{convertNumbersToCard()} {Bet} {CamelCardHandType}";
        }

        private string convertNumbersToCard()
        {
            var returnString = string.Empty;
            foreach(var card in CamelCardHand.Cards)
            {
                returnString += convertNumberToCard(card);
            }
            return returnString;
        }

        private string convertNumberToCard(int number)
        {
            if (number == 10) return "T";
            if (number == 11 || number == 1) return "J";
            if (number == 12) return "Q";
            if (number == 13) return "K";
            if (number == 14) return "A";
            return $"{number}";
        }
    }
}
