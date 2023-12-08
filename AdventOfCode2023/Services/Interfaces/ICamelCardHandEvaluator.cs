using AdventOfCode2023.Models.CamelCards.Interfaces;
using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Services.Interfaces
{
    public interface ICamelCardHandEvaluator
    {
        CamelCardHandType Evaluate(ICamelCardHand camelCardHand);
    }
}
