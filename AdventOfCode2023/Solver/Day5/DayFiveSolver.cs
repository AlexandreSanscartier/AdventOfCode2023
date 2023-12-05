using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Gardens;

namespace AdventOfCode2023.Solver.day5
{
	public class DayFiveSolver : BaseSolver<GardenAlmanac>
	{
		public DayFiveSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayFiveInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 5;

		public override string SolvePartOne(GardenAlmanac input)
		{
			var minLocation = long.MaxValue;
			foreach (var seed in input.SeedsThatNeedPlanting)
			{
				// seed-to-soil map:
				var soil = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Seed).MapFromSourceToDestination(seed);

				//soil-to-fertilizer map:
				var fertilizer = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Soil).MapFromSourceToDestination(soil);

				//fertilizer-to-water map:
				var water = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Fertilizer).MapFromSourceToDestination(fertilizer);

				//water-to-light map:
				var light = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Water).MapFromSourceToDestination(water);

				//light-to-temperature map:
				var temperature = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Light).MapFromSourceToDestination(light);

				//temperature-to-humidity map:
				var humidity = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Temperature).MapFromSourceToDestination(temperature);

				//humidity-to-location map:
				var location = input.GetMappingForSourceType(Models.Enum.GardenAlmanacMappingType.Humidity).MapFromSourceToDestination(humidity);

				if (location < minLocation) minLocation = location;
			}

			return minLocation.ToString();
		}

		public override string SolvePartTwo(GardenAlmanac input)
		{
			return this.SolvePartOne(input);
		}
	}
}
