using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day9;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Tests
{
	public class DayNineTests : ISolverFactTests
	{
		private readonly int _day = 9;
		private readonly string _sampleProblemInput = "0 3 6 9 12 15\n1 3 6 10 15 21\n10 13 16 21 30 45";
		private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = null;

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayNineInputParser();
			var expectedResult = new List<OasisReport>()
			{
				new OasisReport() { ValueHistory = new List<long>() { 0, 3, 6, 9, 12, 15 } },
				new OasisReport() { ValueHistory = new List<long>() { 1, 3, 6, 10, 15, 21 } },
				new OasisReport() { ValueHistory = new List<long>() { 10, 13, 16, 21, 30, 45 } }
            };

			//Act
			var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void SampleInput_PartTwo_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayNineInputParser();
			var expectedResult = new List<OasisReport>()
            {
                new OasisReport() { ValueHistory = new List<long>() { 0, 3, 6, 9, 12, 15 } },
                new OasisReport() { ValueHistory = new List<long>() { 1, 3, 6, 10, 15, 21 } },
                new OasisReport() { ValueHistory = new List<long>() { 10, 13, 16, 21, 30, 45 } }
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
			var inputParser = new DayNineInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayNineSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "114";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DayNineInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DayNineSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "2";

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
			var inputParser = new DayNineInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayNineSolver(problemInputReader, problemOutputReaderMock, inputParser);
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
			var inputParser = new DayNineInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayNineSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

	}
}
