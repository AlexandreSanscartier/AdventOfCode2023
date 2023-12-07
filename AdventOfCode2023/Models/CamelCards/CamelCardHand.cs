using AdventOfCode2023.Models.CamelCards.Interfaces;

namespace AdventOfCode2023.Models.CamelCards
{
    public class CamelCardHand : ICamelCardHand
    {
        private List<int> _cards;
        public IEnumerable<int> Cards => _cards;

        public CamelCardHand(IEnumerable<int> cards)
        {
            _cards = cards.ToList();
        }
    }
}
