using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Models.Maps
{
    public class MapNode : IMapNode
    {
        public MapNode()
        {
            NodeRepresentation = string.Empty;
            LeftDestination = this;
            RightDestination = this;
        }

        public MapNode(string nodeRepresentation) {
            NodeRepresentation = nodeRepresentation;
            LeftDestination = this;
            RightDestination = this;
        }

        public string NodeRepresentation { get; set; }
        public IMapNode LeftDestination { get; set; }
        public IMapNode RightDestination { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is MapNode node &&
                   NodeRepresentation.Equals(node.NodeRepresentation) &&
                   LeftDestination.NodeRepresentation.Equals(node.LeftDestination.NodeRepresentation) &&
                   RightDestination.NodeRepresentation.Equals(node.RightDestination.NodeRepresentation);
        }

        public void SetLeftDestination(IMapNode mapNode)
        {
            LeftDestination = mapNode;
        }

        public void SetRightDestination(IMapNode mapNode)
        {
            RightDestination = mapNode;
        }
    }
}
