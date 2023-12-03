namespace AdventOfCode2023.Models.Interfaces
{
    public interface IPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        IPosition Add(IPosition position);
    }
}
