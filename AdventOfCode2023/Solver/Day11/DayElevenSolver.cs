using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Maps;

namespace AdventOfCode2023.Solver.day11
{
	public class DayElevenSolver : BaseSolver<GalaxyMap>
	{
		public DayElevenSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayElevenInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 11;

		public override string SolvePartOne(GalaxyMap input)
		{
			List<int> distances = new();
			var allGalaxies = input.GetAllGalaxies();
			var addedGalaxies = 0;

			var expandedRows = input.GetExpandedRows();
			var expandedColumns = input.GetExpandedColums();

			for(int i = 0; i < allGalaxies.Count; i++)
			{
				for(int k = i+1;  k < allGalaxies.Count; k++) {
					var galaxyOne = allGalaxies[i];
					var galaxyTwo = allGalaxies[k];

                    var distance = Math.Abs(galaxyOne.X - galaxyTwo.X) + Math.Abs(galaxyOne.Y - galaxyTwo.Y);

					var rowPassthrough = expandedRows.Where(x => x > allGalaxies[i].Y && x < allGalaxies[k].Y || x > allGalaxies[k].Y && x < allGalaxies[i].Y).Count();
					var colPassthrough = expandedColumns.Where(x => x > allGalaxies[i].X && x < allGalaxies[k].X || x > allGalaxies[k].X && x < allGalaxies[i].X).Count();

                    distances.Add(distance + rowPassthrough + colPassthrough);
					addedGalaxies++;
                }
			}
			var sum = distances.Sum().ToString();
            return sum;
		}

		public override string SolvePartTwo(GalaxyMap input)
		{
            List<long> distances = new();
            var allGalaxies = input.GetAllGalaxies();
            var addedGalaxies = 0;

            var expandedRows = input.GetExpandedRows();
            var expandedColumns = input.GetExpandedColums();

            for (int i = 0; i < allGalaxies.Count; i++)
            {
                for (int k = i + 1; k < allGalaxies.Count; k++)
                {
                    var galaxyOne = allGalaxies[i];
                    var galaxyTwo = allGalaxies[k];

                    var distance = Math.Abs(galaxyOne.X - galaxyTwo.X) + Math.Abs(galaxyOne.Y - galaxyTwo.Y);

                    var rowPassthrough = expandedRows.Where(x => x > allGalaxies[i].Y && x < allGalaxies[k].Y || x > allGalaxies[k].Y && x < allGalaxies[i].Y).Count();
                    var colPassthrough = expandedColumns.Where(x => x > allGalaxies[i].X && x < allGalaxies[k].X || x > allGalaxies[k].X && x < allGalaxies[i].X).Count();

                    distances.Add(distance + (rowPassthrough * 1000000) + (colPassthrough * 1000000) - rowPassthrough - colPassthrough);
                    addedGalaxies++;
                }
            }
            var sum = distances.Sum().ToString();
            return sum;
        }
	}
}
