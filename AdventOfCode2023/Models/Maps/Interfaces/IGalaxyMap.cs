using AdventOfCode2023.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Models.Maps.Interfaces
{
    public interface IGalaxyMap
    {
        List<List<char>> GetMap { get; }

        List<char> GetRowAt(int row);

        List<char> GetColumnAt(int col);

        bool IsRowExpanded(int row);

        bool IsColumnExpanded(int col);

        List<int> GetExpandedRows();

        List<int> GetExpandedColums();

        char GetCharRepresentationAt(IPosition position);
        List<IPosition> GetAllGalaxies();
    }
}
