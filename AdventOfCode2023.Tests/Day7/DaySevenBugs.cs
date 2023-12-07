using AdventOfCode2023.Models.CamelCards;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Services;

namespace AdventOfCode2023.Tests.Day7
{
    public class DaySevenBugs
    {
        [Theory]
        [InlineData(new[] { 12, 10, 1, 3, 1 }, CamelCardHandType.ThreeOfAKind)]
        [InlineData(new[] { 12, 10, 12, 10, 1 }, CamelCardHandType.FullHouse)]
        [InlineData(new[] { 12, 10, 1, 10, 1 }, CamelCardHandType.FourOfAKind)]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, CamelCardHandType.FiveOfAKind)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, CamelCardHandType.OnePair)]
        [InlineData(new[] { 1, 1, 1, 8, 1 }, CamelCardHandType.FiveOfAKind)]// "JJJ8J 317 HighCard"
        public void WhenUsingJokers_Successfully_EvaluatesTheHand(int[] cards, CamelCardHandType expectedResult)
        {
            // Arrange
            var cardHand = new CamelCardHand(cards.ToList());
            var handEvaluator = new CamelCardJokerHandEvaluator();

            // Act
            var result = handEvaluator.Evaluate(cardHand);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
