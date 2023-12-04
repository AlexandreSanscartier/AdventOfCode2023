using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class ScratchCard : IScratchCard
    {
        private List<int> _winningNumbers;
        private List<int> _numbersYouHave;

        public IEnumerable<int> WinningNumbers => _winningNumbers;
        public IEnumerable<int> NumbersYouHave => _numbersYouHave;

        public ScratchCard(List<int> winningNumbers, List<int> numbersYouHave)
        {
            _winningNumbers = winningNumbers;
            _numbersYouHave = numbersYouHave;
        }

        public override bool Equals(object? obj)
        {
            return obj is ScratchCard card &&
                    card.WinningNumbers.Count() == WinningNumbers.Count() &&
                    card.WinningNumbers.All(x => WinningNumbers.Contains(x)) &&
                    card.NumbersYouHave.Count() == NumbersYouHave.Count() &&
                    card.NumbersYouHave.All(x => NumbersYouHave.Contains(x));
        }
    }
}
