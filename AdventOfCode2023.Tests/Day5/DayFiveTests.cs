using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day5;
using AdventOfCode2023.Models.Gardens;
using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Tests
{
	public class DayFiveTests : ISolverFactTests
	{
		private readonly int _day = 5;
		private readonly string _sampleProblemInput = "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4";
		private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = null;

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayFiveInputParser();
			var expectedResult = GenerateTestGardenAlmanac();

            //Act
            var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		private GardenAlmanac GenerateTestGardenAlmanac()
		{
			var gardenAlmanac = new GardenAlmanac();

			gardenAlmanac.AddSeedToPlant(79);
			gardenAlmanac.AddSeedToPlant(14);
			gardenAlmanac.AddSeedToPlant(55);
			gardenAlmanac.AddSeedToPlant(13);

            //seed-to-soil map:
            //50 98 2
			//52 50 48
            gardenAlmanac.AddMapping(new GardenMappings()
			{
				DestinationType = Models.Enum.GardenAlmanacMappingType.Soil,
				SourceType = Models.Enum.GardenAlmanacMappingType.Seed,
				Mappings = new List<IGardenMapping>()
				{
                    GenerateGardenMapping(50,98,2),
                    GenerateGardenMapping(52,50,48)
                }
			});

			//soil-to-fertilizer map:
			//0 15 37
			//37 52 2
			//39 0 15
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Fertilizer,
                SourceType = Models.Enum.GardenAlmanacMappingType.Soil,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(0,15,37),
                    GenerateGardenMapping(37,52,2),                 
                    GenerateGardenMapping(39,0,15)
                }
            });

            //fertilizer-to-water map:
            //49 53 8
            //0 11 42
            //42 0 7
            //57 7 4
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Water,
                SourceType = Models.Enum.GardenAlmanacMappingType.Fertilizer,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(49,53,8),
                    GenerateGardenMapping(0,11,42),
                    GenerateGardenMapping(42,0,7),
                    GenerateGardenMapping(57,7,4)
                }
            });

            //water-to-light map:
            //88 18 7
            //18 25 70
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Light,
                SourceType = Models.Enum.GardenAlmanacMappingType.Water,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(88,18,7),
                    GenerateGardenMapping(18,25,70),
                }
            });

            //light-to-temperature map:
            //45 77 23
            //81 45 19
            //68 64 13
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Temperature,
                SourceType = Models.Enum.GardenAlmanacMappingType.Light,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(45,77,23),
                    GenerateGardenMapping(81,45,19),
                    GenerateGardenMapping(68,64,13),
                }
            });

            //temperature-to-humidity map:
            //0 69 1
            //1 0 69
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Humidity,
                SourceType = Models.Enum.GardenAlmanacMappingType.Temperature,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(0,69,1),
                    GenerateGardenMapping(1,0,69),
                }
            });

            //humidity-to-location map:
            //60 56 37
            //56 93 4
            gardenAlmanac.AddMapping(new GardenMappings()
            {
                DestinationType = Models.Enum.GardenAlmanacMappingType.Location,
                SourceType = Models.Enum.GardenAlmanacMappingType.Humidity,
                Mappings = new List<IGardenMapping>()
                {
                    GenerateGardenMapping(60,56,37),
                    GenerateGardenMapping(56,93,4),
                }
            });

            return gardenAlmanac;
		}

		private IGardenMapping GenerateGardenMapping(int destination, int source, int length)
		{
			return new GardenMapping()
			{
				DestinationRangeStart = destination,
				SourceRangeStart = source,
				RangeLength = length
			};
        }

		[Fact]
		public void SampleInput_PartTwo_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayFiveInputParser();
			var expectedResult = new GardenAlmanac();

			//Act
			var result = inputParser.ParseProblemTwoInput(this.SampleProblemTwoInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartOne()
		{
			//Arrange
			var inputParser = new DayFiveInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayFiveSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DayFiveInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DayFiveSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task PartOne_ProducesCorrectResult()
		{
			//Arrange
			var problemInput = InputFileReaderHelper.ReadFile(this.Day);
			var inputParser = new DayFiveInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayFiveSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task PartTwo_ProducesCorrectResult()
		{
			//Arrange
			var problemInput = InputFileReaderHelper.ReadFile(this.Day);
			var inputParser = new DayFiveInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayFiveSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

	}
}
