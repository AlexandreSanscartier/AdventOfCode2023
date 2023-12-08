using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Maps.Interfaces
{
    public interface IMapInstruction
    {
        List<MapDirectionType> Directions { get; set; }

        List<IMapNode> StartingNodes { get; set; }
    }
}
