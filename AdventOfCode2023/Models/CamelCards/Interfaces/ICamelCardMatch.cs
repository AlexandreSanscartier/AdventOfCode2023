using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.CamelCards.Interfaces
{
    public interface ICamelCardMatch
    {
        ICamelCardHand CamelCardHand { get; set; }

        int Bet { get; set; }

        CamelCardHandType CamelCardHandType { get; set; }
    }
}
