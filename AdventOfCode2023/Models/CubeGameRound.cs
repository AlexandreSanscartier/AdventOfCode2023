using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class CubeGameRound : ICubeGameRound
    {
        private Dictionary<Cube, int> _revealedCubes;
        public Dictionary<Cube, int> RevealedCubes { get; set; }

        public CubeGameRound()
        {
            RevealedCubes = new Dictionary<Cube, int>();
        }

        public void AddCube(Cube cube, int amount)
        {
            RevealedCubes.Add(cube, amount);
        }

        public override bool Equals(object? obj)
        {
            bool dictionariesEqual =
                obj is CubeGameRound round &&
                round.RevealedCubes.Count == RevealedCubes.Keys.Count &&
                round.RevealedCubes.Keys.All(k => RevealedCubes.ContainsKey(k) && object.Equals(round.RevealedCubes[k], RevealedCubes[k]));
            return dictionariesEqual;
        }
    }
}
