using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Gardens;
using System.IO.Pipes;

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
			var foundSeed = false;
			var maxLocation = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Location).Mappings.Select(x => (x.DestinationRangeStart + x.RangeLength)).Max();
			do
			{
				for(long i = 0; i < maxLocation; i++)
				{
					var humidity = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Location).MapFromDestinationToSource(i);
					var temperature = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Humidity).MapFromDestinationToSource(humidity);
					var light = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Temperature).MapFromDestinationToSource(temperature);
					var water = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Light).MapFromDestinationToSource(light);
                    var fertilizer = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Water).MapFromDestinationToSource(water);
                    var soil = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Fertilizer).MapFromDestinationToSource(fertilizer);
                    var seed = input.GetMappingForDestinationType(Models.Enum.GardenAlmanacMappingType.Soil).MapFromDestinationToSource(soil);
					if (input.SeedsThatNeedPlanting.Contains(seed)) return i.ToString();
                }
            } while (!foundSeed);
			return maxLocation.ToString();
        }
	}
}
