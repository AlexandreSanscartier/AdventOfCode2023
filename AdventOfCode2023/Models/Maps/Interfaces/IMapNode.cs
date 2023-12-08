using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Models.Maps.Interfaces
{
    public interface IMapNode
    {
        string NodeRepresentation { get; set; }

        IMapNode LeftDestination { get; set; }

        IMapNode RightDestination { get; set; }

        void SetLeftDestination(IMapNode mapNode);
        void SetRightDestination(IMapNode mapNode);
    }
}
