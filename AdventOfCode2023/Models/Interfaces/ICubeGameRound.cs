namespace AdventOfCode2023.Models.Interfaces
{
    public interface ICubeGameRound
    {
        Dictionary<Cube, int> RevealedCubes { get; set; }

        void AddCube(Cube cube, int amount);
    }
}
