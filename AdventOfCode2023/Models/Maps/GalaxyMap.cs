using AdventOfCode2023.Models.Interfaces;
using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Models.Maps
{
    public class GalaxyMap : IGalaxyMap
    {
        private readonly List<List<char>> _universeMap;

        public GalaxyMap(List<List<char>> universeMap)
        {
            _universeMap = universeMap;
        }

        public List<List<char>> GetMap => _universeMap;

        public override bool Equals(object? obj)
        {
            return obj is GalaxyMap map &&
                MapsAreEqual(map);
        }

        private bool MapsAreEqual(GalaxyMap map)
        {
            if (GetMap.Count != map.GetMap.Count) return false;
            for (int i = 0; i < _universeMap.Count; i++)
            {
                if (GetMap[i].Count != map.GetMap[i].Count) return false;
                for (int k = 0; k < _universeMap[i].Count; k++)
                {
                    if (!GetMap[i][k].Equals(map.GetMap[i][k])) return false;
                }
            }
            return true;
        }

        public List<IPosition> GetAllGalaxies()
        {
            var galaxyPositions = new List<IPosition>();
            for(int i = 0; i < _universeMap.Count; i++)
            {
                for(int k = 0; k < _universeMap[i].Count; k++)
                {
                    if (_universeMap[i][k].Equals('#'))
                        galaxyPositions.Add(new Position(k, i));
                }
            }
            return galaxyPositions;
        }

        public char GetCharRepresentationAt(IPosition position)
        {
            return _universeMap[position.Y][position.X];
        }

        public List<char> GetColumnAt(int col)
        {
            var cols = new List<char>();
            for (int i = 0; i < _universeMap.Count; i++)
            {
                for (int k = 0; k < _universeMap[i].Count; k++)
                {
                    if (col == k)
                        cols.Add(_universeMap[i][k]);
                }
            }
            return cols;
        }

        public List<char> GetRowAt(int row)
            => _universeMap[row];

        public bool IsColumnExpanded(int col)
        {
            var columns = GetColumnAt(col);
            return columns.TrueForAll(x => x.Equals('.'));
        }

        public bool IsRowExpanded(int row)
        {
            var rows = GetRowAt(row);
            return rows.TrueForAll(x => x.Equals('.'));
        }

        public List<int> GetExpandedRows()
        {
            var expandedRows = new List<int>();
            for (int i = 0; i < _universeMap.Count; i++)
            {
                if(IsRowExpanded(i))
                    expandedRows.Add(i);
            }
            return expandedRows;
        }

        public List<int> GetExpandedColums()
        {
            var expandedCols = new List<int>();
            for (int k = 0; k < _universeMap.Count; k++)
            {
                if (IsColumnExpanded(k))
                    expandedCols.Add(k);
            }
            return expandedCols;
        }
    }
}
