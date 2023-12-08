using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Models.Maps
{
    public class MapInstruction : IMapInstruction
    {
        public List<MapDirectionType> Directions { get; set; }
        public List<IMapNode> StartingNodes { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is MapInstruction instruction &&
                Directions.Count == instruction.Directions.Count &&
                Directions.All(x => instruction.Directions.Contains(x)) &&
                StartingNodes.Count == instruction.StartingNodes.Count &&
                StartingNodes.All(x => instruction.StartingNodes.Contains(x));
        }
    }
}
