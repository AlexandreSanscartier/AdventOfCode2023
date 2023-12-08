using AdventOfCode2023.Models.CamelCards;
using AdventOfCode2023.Models.CamelCards.Interfaces;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2023.Services
{
    public class CamelCardHandEvaluator : ICamelCardHandEvaluator
    {
        public CamelCardHandType Evaluate(ICamelCardHand camelCardHand)
        {
            if (IsFiveOfAKind(camelCardHand)) return CamelCardHandType.FiveOfAKind;
            if (IsFourOfAKind(camelCardHand)) return CamelCardHandType.FourOfAKind;
            if(IsFullHouse(camelCardHand)) return CamelCardHandType.FullHouse;
            if (IsThreeOfAKind(camelCardHand)) return CamelCardHandType.ThreeOfAKind;
            if (IsTwoPair(camelCardHand)) return CamelCardHandType.TwoPair;
            if (IsOnePair(camelCardHand)) return CamelCardHandType.OnePair;
            return CamelCardHandType.HighCard; // Will always be a high card if it doesn't fit any other criteria
        }

        private bool IsFiveOfAKind(ICamelCardHand camelCardHand)
        {
            return camelCardHand.Cards.All(x => x.Equals(camelCardHand.Cards.First()));
        }

        private bool IsFourOfAKind(ICamelCardHand camelCardHand)
        {
            var camelCardHandGrouped = camelCardHand.Cards.GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
            });
            return camelCardHandGrouped.Any(x => x.NumberOfCards == 4);
        }

        private bool IsFullHouse(ICamelCardHand camelCardHand)
        {
            var camelCardHandGrouped = camelCardHand.Cards.GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                }).OrderBy(x => x.NumberOfCards);

            return camelCardHandGrouped.Count() == 2 && camelCardHandGrouped.First().NumberOfCards == 2 && camelCardHandGrouped.Last().NumberOfCards == 3;
        }

        private bool IsThreeOfAKind(ICamelCardHand camelCardHand)
        {
            var camelCardHandGrouped = camelCardHand.Cards.GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });
            return camelCardHandGrouped.Any(x => x.NumberOfCards == 3);
        }

        private bool IsTwoPair(ICamelCardHand camelCardHand)
        {
            var camelCardHandGrouped = camelCardHand.Cards.GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
            });

            return camelCardHandGrouped.Where(x => x.NumberOfCards == 2).Count() == 2;
        }

        private bool IsOnePair(ICamelCardHand camelCardHand)
        {
            var camelCardHandGrouped = camelCardHand.Cards.GroupBy(x => x).Select(x =>
                new {
                    x.Key,
                    NumberOfCards = x.Count()
                });

            return camelCardHandGrouped.Where(x => x.NumberOfCards == 2).Count() == 1;
        }
    }
}
