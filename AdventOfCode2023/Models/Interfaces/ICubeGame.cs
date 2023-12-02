namespace AdventOfCode2023.Models.Interfaces
{
    public interface ICubeGame
    {
        int Id { get; set; }
        IEnumerable<ICubeGameRound> Rounds { get; }

        void AddRound(ICubeGameRound round);
    }
}
