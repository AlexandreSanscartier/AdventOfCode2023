using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day8;
using AdventOfCode2023.Models.Maps;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Maps.Interfaces;

namespace AdventOfCode2023.Tests
{
	public class DayEightTests : ISolverFactTests
	{
		private readonly int _day = 8;
		private readonly string _sampleProblemInput = "LLR\n\nAAA = (BBB, BBB)\nBBB = (AAA, ZZZ)\nZZZ = (ZZZ, ZZZ)";
        private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = "LR\n\n11A = (11B, XXX)\n11B = (XXX, 11Z)\n11Z = (11B, XXX)\n22A = (22B, XXX)\n22B = (22C, 22C)\n22C = (22Z, 22Z)\n22Z = (22B, 22B)\nXXX = (XXX, XXX)";

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayEightInputParser();
			var expectedResult = new MapInstruction()
			{
				Directions = new List<MapDirectionType>()
				{
					MapDirectionType.Left, MapDirectionType.Left, MapDirectionType.Right
				},
				StartingNodes = new List<IMapNode>() { GenerateMapNodes() }
			};

			//Act
			var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		private IEnumerable<IMapNode> GeneratePartTwoMapNodes()
		{
			var A11 = new MapNode() { NodeRepresentation = "11A" };
			var B11 = new MapNode() { NodeRepresentation = "11B" };
			var Z11 = new MapNode() { NodeRepresentation = "11Z" };
			var A22 = new MapNode() { NodeRepresentation = "22A" };
			var B22 = new MapNode() { NodeRepresentation = "22B" };
			var C22 = new MapNode() { NodeRepresentation = "22C" };
			var Z22 = new MapNode() { NodeRepresentation = "22Z" };
			var XXX = new MapNode() { NodeRepresentation = "XXX" };

			A11.LeftDestination = B11;
			A11.RightDestination = XXX;

			B11.LeftDestination = XXX;
			B11.RightDestination = Z11;

			Z11.LeftDestination = B11;
			Z11.RightDestination = XXX;

			A22.LeftDestination = B22;
			A22.LeftDestination = XXX;

			B22.LeftDestination = C22;
			B22.RightDestination = C22;

			C22.LeftDestination = Z22;
			C22.RightDestination = Z22;

			Z22.LeftDestination = B22;
			Z22.RightDestination = B22;

			XXX.LeftDestination = XXX;
			XXX.RightDestination = XXX;

            return new List<IMapNode>() { A11, A22 };
        }

        private IMapNode GenerateMapNodes()
        {
            var ZZZ = new MapNode() { NodeRepresentation = "ZZZ" };
            var AAA = new MapNode() { NodeRepresentation = "AAA" };
            var BBB = new MapNode() { NodeRepresentation = "BBB" };

            AAA.RightDestination = BBB;
            AAA.LeftDestination = BBB;

            BBB.LeftDestination = AAA;
            BBB.RightDestination = ZZZ;

            ZZZ.LeftDestination = ZZZ;
            ZZZ.RightDestination = ZZZ;

            return AAA;
        }

        [Fact]
		public void SampleInput_PartTwo_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayEightInputParser();
            var expectedResult = new MapInstruction()
            {
                Directions = new List<MapDirectionType>()
                {
                    MapDirectionType.Left, MapDirectionType.Right
                },
                StartingNodes = GeneratePartTwoMapNodes().ToList()
            };

            //Act
            var result = inputParser.ParseProblemTwoInput(this.SampleProblemTwoInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartOne()
		{
			//Arrange
			var inputParser = new DayEightInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayEightSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "6";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DayEightInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DayEightSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "6";

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
			var inputParser = new DayEightInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayEightSolver(problemInputReader, problemOutputReaderMock, inputParser);
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
			var inputParser = new DayEightInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayEightSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

	}
}
