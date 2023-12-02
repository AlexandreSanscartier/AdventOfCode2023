using AdventOfCode2023.Solver.day1;
using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;

namespace AdventOfCode2023.Tests
{
    public class DayOneTests : ISolverFactTests
	{
		private readonly int _day = 1;
		private readonly string _sampleProblemInput = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
		private readonly string _samplePartTwoInput = "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";

        public int Day => _day;

        public string SampleProblemOneInput => _sampleProblemInput;

        public string SampleProblemTwoInput => _samplePartTwoInput;

        [Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayOneInputParser();
			var expectedResults = new List<int>()
			{
				12,
				38,
				15,
				77
			};

			//Act
			var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResults, result);

		}

        [Fact]
        public void SampleInput_PartTwo_ParsesCorrectly()
        {
            //Arrange
            var inputParser = new DayOneInputParser();
            var expectedResults = new List<int>()
            {
                29,
                83,
                13,
                24,
				42,
				14,
				76
            };

            //Act
            var result = inputParser.ParseProblemTwoInput(this.SampleProblemTwoInput);

            //Assert
            Assert.Equal(expectedResults, result);

        }

        [Fact]
		public async Task SampleInput_ProducesCorrectResultForPartOne()
		{
			//Arrange
			var inputParser = new DayOneInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayOneSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "142";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
            //Arrange
            var inputParser = new DayOneInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

            var solver = new DayOneSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "281";

            //Act
            var result = await solver.SolvePartTwoAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }

		[Fact]
		public async Task PartOne_ProducesCorrectResult()
		{
            // Arrange
            var problemInput = InputFileReaderHelper.ReadFile(this.Day);
            var inputParser = new DayOneInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

            var solver = new DayOneSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "54644";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
        }

		[Fact]
		public async Task PartTwo_ProducesCorrectResult()
		{
            // Arrange
            var problemInput = InputFileReaderHelper.ReadFile(this.Day);
            var inputParser = new DayOneInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

            var solver = new DayOneSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "53348";

            //Act
            var result = await solver.SolvePartTwoAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }
	}
}
