using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Gardens;
using AdventOfCode2023.Models.Interfaces.Gardens;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day5

{
	public class DayFiveInputParser : BaseInputParser<GardenAlmanac>, IDayFiveInputParser
	{
		public override GardenAlmanac Parse(string input)
		{
			var inputParts = input.Split('\n');
			
			var gardenAlmanac = new GardenAlmanac();
			var preSplit = inputParts[0].Split(':')[1].Trim().Split(' ').ToList();
            preSplit.ForEach(x => gardenAlmanac.AddSeedToPlant(long.Parse(x)));
			var mappings = inputParts.Skip(2);

			var source = GardenAlmanacMappingType.None;
			var destination = GardenAlmanacMappingType.None;
			var gardenMappings = new List<IGardenMapping>();
            foreach (var map in mappings)
			{
				if (map.Contains("-to-"))
				{
					var header = map.Split(' ')[0].Split("-to-");
					source = StringToGardenAlmanacMappingType(header[0]);
					destination = StringToGardenAlmanacMappingType(header[1]);
				} 
				else if(!string.IsNullOrEmpty(map))
				{
					var gardenMapping = map.Split(' ').ToList().Select(x => long.Parse(x)).ToList();
					gardenMappings.Add(new GardenMapping()
					{
						DestinationRangeStart = gardenMapping[0],
						SourceRangeStart = gardenMapping[1],
						RangeLength = gardenMapping[2]
					});
				}
				else
				{
					gardenAlmanac.AddMapping(new GardenMappings()
					{
						DestinationType = destination,
						SourceType = source,
						Mappings = gardenMappings
					});
					destination = GardenAlmanacMappingType.None;
					source = GardenAlmanacMappingType.None;
                    gardenMappings = new();
                }
            }

			if(gardenMappings.Any())
			{
                gardenAlmanac.AddMapping(new GardenMappings()
                {
                    DestinationType = destination,
                    SourceType = source,
                    Mappings = gardenMappings
                });
                destination = GardenAlmanacMappingType.None;
                source = GardenAlmanacMappingType.None;
                gardenMappings = new();
            }


			return gardenAlmanac;
		}

        public override GardenAlmanac ParseProblemTwoInput(string input)
        {
            var inputParts = input.Split('\n');

            var gardenAlmanac = new GardenAlmanac();
            var preSplits = inputParts[0].Split(':')[1].Trim().Split(' ').ToList();
            for(int i = 0; i < preSplits.Count - 1; i+=2)
            {
                var seed = long.Parse(preSplits[i]);
                var range = long.Parse(preSplits[i + 1]);
                var seedRange = new SeedRange()
                {
                    SeedStart = seed,
                    Range = range
                };
                gardenAlmanac.AddSeedRange(seedRange);
            }
            var mappings = inputParts.Skip(2);

            var source = GardenAlmanacMappingType.None;
            var destination = GardenAlmanacMappingType.None;
            var gardenMappings = new List<IGardenMapping>();
            foreach (var map in mappings)
            {
                if (map.Contains("-to-"))
                {
                    var header = map.Split(' ')[0].Split("-to-");
                    source = StringToGardenAlmanacMappingType(header[0]);
                    destination = StringToGardenAlmanacMappingType(header[1]);
                }
                else if (!string.IsNullOrEmpty(map))
                {
                    var gardenMapping = map.Split(' ').ToList().Select(x => long.Parse(x)).ToList();
                    gardenMappings.Add(new GardenMapping()
                    {
                        DestinationRangeStart = gardenMapping[0],
                        SourceRangeStart = gardenMapping[1],
                        RangeLength = gardenMapping[2]
                    });
                }
                else
                {
                    gardenAlmanac.AddMapping(new GardenMappings()
                    {
                        DestinationType = destination,
                        SourceType = source,
                        Mappings = gardenMappings
                    });
                    destination = GardenAlmanacMappingType.None;
                    source = GardenAlmanacMappingType.None;
                    gardenMappings = new();
                }
            }

            if (gardenMappings.Any())
            {
                gardenAlmanac.AddMapping(new GardenMappings()
                {
                    DestinationType = destination,
                    SourceType = source,
                    Mappings = gardenMappings
                });
                destination = GardenAlmanacMappingType.None;
                source = GardenAlmanacMappingType.None;
                gardenMappings = new();
            }


            return gardenAlmanac;
        }

        private GardenAlmanacMappingType StringToGardenAlmanacMappingType(string inputString)
		{
			return inputString switch
			{
				"seed" => GardenAlmanacMappingType.Seed,
				"soil" => GardenAlmanacMappingType.Soil,
                "fertilizer" => GardenAlmanacMappingType.Fertilizer,
				"water" => GardenAlmanacMappingType.Water,
				"light" => GardenAlmanacMappingType.Light,
				"temperature" => GardenAlmanacMappingType.Temperature,
				"humidity" => GardenAlmanacMappingType.Humidity,
				"location" => GardenAlmanacMappingType.Location
			};
		}
	}
}
