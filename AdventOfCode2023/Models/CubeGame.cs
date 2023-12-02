using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class CubeGame : ICubeGame
    {
        private List<ICubeGameRound> _rounds = new();
        public IEnumerable<ICubeGameRound> Rounds => _rounds;

        public int Id { get; set; }

        public void AddRound(ICubeGameRound round)
        {
            this._rounds.Add(round);
        }

        public override bool Equals(object? obj)
        {
            return obj is CubeGame game &&
                   game.Rounds.Count() == Rounds.Count() &&
                   game.Rounds.All(x => Rounds.Contains(x)) &&
                   Id == game.Id;
        }
    }
}
