using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Models.Maps
{
    public class MapInstruction : IMapInstruction
    {
        public List<MapDirectionType> Directions { get; set; }
        public IMapNode StartingNode { get; set; }
    }
}
