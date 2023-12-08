using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Models.Maps
{
    public class MapNode : IMapNode
    {
        public string NodeRepresentation { get; set; }
        public IMapNode LeftDestination { get; set; }
        public IMapNode RightDestination { get; set; }
    }
}
