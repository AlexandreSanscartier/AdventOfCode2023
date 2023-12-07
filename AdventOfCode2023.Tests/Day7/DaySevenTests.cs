using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day7;
using AdventOfCode2023.Models.CamelCards;

namespace AdventOfCode2023.Tests
{
	public class DaySevenTests : ISolverFactTests
	{
		private readonly int _day = 7;
		private readonly string _sampleProblemInput = "32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483";
		private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = null;

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DaySevenInputParser();
			var expectedResult = new List<CamelCardMatch>()
			{
				new CamelCardMatch() {
					CamelCardHand = new CamelCardHand(new List<int>() { 3,2,10,3,13 } ),
					Bet = 765
				},
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 10,5,5,11,5 } ),
                    Bet = 684
                },
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 13,13,6,7,7 } ),
                    Bet = 28
                },
				new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 13,10,11,11,10 } ),
                    Bet = 220
                },
				new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 12,12,12,11,14 } ),
                    Bet = 483
                },
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
			var inputParser = new DaySevenInputParser();
            var expectedResult = new List<CamelCardMatch>()
            {
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 3,2,10,3,13 } ),
                    Bet = 765
                },
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 10,5,5,1,5 } ),
                    Bet = 684
                },
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 13,13,6,7,7 } ),
                    Bet = 28
                },
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 13,10,1,1,10 } ),
                    Bet = 220
                },
                new CamelCardMatch() {
                    CamelCardHand = new CamelCardHand(new List<int>() { 12,12,12,1,14 } ),
                    Bet = 483
                },
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
			var inputParser = new DaySevenInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DaySevenSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "6440";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DaySevenInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DaySevenSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "5905";

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
			var inputParser = new DaySevenInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DaySevenSolver(problemInputReader, problemOutputReaderMock, inputParser);
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
			var inputParser = new DaySevenInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DaySevenSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

	}
}
