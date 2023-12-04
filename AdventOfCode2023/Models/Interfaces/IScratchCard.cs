namespace AdventOfCode2023.Models.Interfaces
{
    public interface IScratchCard
    {
        IEnumerable<int> WinningNumbers { get; }

        IEnumerable<int> NumbersYouHave { get; }
    }
}
