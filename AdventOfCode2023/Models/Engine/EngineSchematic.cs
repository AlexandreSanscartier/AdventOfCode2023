using AdventOfCode2023.Models.Interfaces;
using AdventOfCode2023.Models.Interfaces.Engine;

namespace AdventOfCode2023.Models.Engine
{
    public class EngineSchematic : IEngineSchematic
    {
        public List<IEngineSchematicPart> Parts { get; set; } = new();
        public int Rows { get; set; }
        public int Columns { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is EngineSchematic engineSchematic &&
                Parts.Count == engineSchematic.Parts.Count &&
                Columns == engineSchematic.Columns &&
                Rows == engineSchematic.Rows &&
                Parts.All(x => engineSchematic.Parts.Contains(x));
        }

        public IEngineSchematicPart? GetPartAtPosition(IPosition position)
        {
            return Parts.Where(x => x.Position.X == position.X && x.Position.Y == position.Y).SingleOrDefault();
        }
    }
}
