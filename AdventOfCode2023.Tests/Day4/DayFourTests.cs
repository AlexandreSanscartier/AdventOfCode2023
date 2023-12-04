using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day4;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Tests
{
	public class DayFourTests : ISolverFactTests
	{
		private readonly int _day = 4;
		private readonly string _sampleProblemInput = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

        private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = null;

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayFourInputParser();
            var expectedResult = GenerateExpectedTestResult();

            //Act
            var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void SampleInput_PartTwo_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayFourInputParser();
			var expectedResult = GenerateExpectedTestResult();

            //Act
            var result = inputParser.ParseProblemTwoInput(this.SampleProblemTwoInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		public List<ScratchCard> GenerateExpectedTestResult()
		{
            var expectedResult = new List<ScratchCard>()
            {
                new ScratchCard(
                    new List<int>() { 41, 48, 83, 86, 17},
                    new List<int>() { 83, 86,  6, 31, 17,  9, 48, 53 }
                ),
                new ScratchCard(
                    new List<int>() { 13, 32, 20, 16, 61},
                    new List<int>() {  61, 30, 68, 82, 17, 32, 24, 19 }
                ),
                new ScratchCard(
                    new List<int>() { 1, 21, 53, 59, 44},
                    new List<int>() { 69, 82, 63, 72, 16, 21, 14,  1 }
                ),
                new ScratchCard(
                    new List<int>() { 41, 92, 73, 84, 69},
                    new List<int>() { 59,84, 76, 51, 58,  5, 54, 83 }
                ),
                new ScratchCard(
                    new List<int>() { 87, 83, 26, 28, 32},
                    new List<int>() { 88, 30, 70, 12, 93, 22, 82, 36 }
                ),
                new ScratchCard(
                    new List<int>() { 31, 18, 13, 56, 72},
                    new List<int>() { 74, 77, 10, 23, 35, 67, 36, 11 }
                ),
            };
			return expectedResult;
        }

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartOne()
		{
			//Arrange
			var inputParser = new DayFourInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayFourSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "13";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DayFourInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DayFourSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "30";

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
			var inputParser = new DayFourInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayFourSolver(problemInputReader, problemOutputReaderMock, inputParser);
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
			var inputParser = new DayFourInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayFourSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

	}
}
