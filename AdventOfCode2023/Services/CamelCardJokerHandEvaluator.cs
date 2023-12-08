using AdventOfCode2023.Models.CamelCards.Interfaces;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Services
{
    public class CamelCardJokerHandEvaluator : ICamelCardHandEvaluator
    {
        public CamelCardHandType Evaluate(ICamelCardHand camelCardHand)
        {
            if (IsFiveOfAKind(camelCardHand)) return CamelCardHandType.FiveOfAKind;
            if (IsFourOfAKind(camelCardHand)) return CamelCardHandType.FourOfAKind;
            if (IsFullHouse(camelCardHand)) return CamelCardHandType.FullHouse;
            if (IsThreeOfAKind(camelCardHand)) return CamelCardHandType.ThreeOfAKind;
            if (IsTwoPair(camelCardHand)) return CamelCardHandType.TwoPair;
            if (IsOnePair(camelCardHand)) return CamelCardHandType.OnePair;
            return CamelCardHandType.HighCard; // Will always be a high card if it doesn't fit any other criteria
        }

        private bool IsFiveOfAKind(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var handWithoutJoker = camelCardHand.Cards.Where(x => x != 1);
            var areAllCardsSame = handWithoutJoker.All(x => x.Equals(handWithoutJoker.First()));
            return areAllCardsSame || numberOfJokers == 5;
        }

        private bool IsFourOfAKind(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var camelCardHandGrouped = camelCardHand.Cards.Where(x => x != 1).GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });
            return camelCardHandGrouped.Any(x => (x.NumberOfCards + numberOfJokers) == 4);
        }

        private bool IsFullHouse(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var camelCardHandGrouped = camelCardHand.Cards.Where(x => x != 1).GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                }).OrderBy(x => x.NumberOfCards);

            return camelCardHandGrouped.Count() == 2 && camelCardHandGrouped.First().NumberOfCards == 2 && (camelCardHandGrouped.Last().NumberOfCards + numberOfJokers) == 3;
        }

        private bool IsThreeOfAKind(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var camelCardHandGrouped = camelCardHand.Cards.Where(x => x != 1).GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });
            return camelCardHandGrouped.Any(x => (x.NumberOfCards + numberOfJokers) == 3);
        }

        private bool IsTwoPair(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var camelCardHandGrouped = camelCardHand.Cards.Where(x => x != 1).GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });

            return camelCardHandGrouped.Where(x => (x.NumberOfCards + numberOfJokers) == 2).Count() == 2;
        }

        private bool IsOnePair(ICamelCardHand camelCardHand)
        {
            var numberOfJokers = camelCardHand.Cards.Count(x => x == 1);
            var camelCardHandGrouped = camelCardHand.Cards.Where(x => x != 1).GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });

            return camelCardHandGrouped.Where(x => (x.NumberOfCards + numberOfJokers) == 2).Count() >= 1;
        }
    }
}
