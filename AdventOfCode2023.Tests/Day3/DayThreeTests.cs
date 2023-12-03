using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day3;
using AdventOfCode2023.Models.Engine;
using AdventOfCode2023.Models.Interfaces.Engine;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Tests
{
	public class DayThreeTests : ISolverFactTests
	{
		private readonly int _day = 3;
		private readonly string _sampleProblemInput = "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..";
        private readonly string? _sampleProblemOneInput = null;
		private readonly string? _sampleProblemTwoInput = null;

		public int Day => _day;

		public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
		public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

		[Fact]
		public void SampleInput_PartOne_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayThreeInputParser();
			var expectedResult = GenerateTestEngineSchematic();

			//Act
			var result = inputParser.ParseProblemOneInput(this.SampleProblemOneInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

		public EngineSchematic GenerateTestEngineSchematic()
		{
            var engineSchematic = new EngineSchematic()
			{
				Columns = 10,
				Rows = 10,
				Parts = new List<IEngineSchematicPart>()
				{
					//467..114..
                    GenerateEngineSchematicPart(0, 0, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(1, 0, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(2, 0, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(3, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 0, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(6, 0, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(7, 0, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(8, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 0, EngineSchematicPartType.NonSymbol, '.'),

					//...*......
                    GenerateEngineSchematicPart(0, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 1, EngineSchematicPartType.Symbol, '*'),
                    GenerateEngineSchematicPart(4, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 1, EngineSchematicPartType.NonSymbol, '.'),
					
					//..35..633.
                    GenerateEngineSchematicPart(0, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(3, 2, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(4, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 2, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(7, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(8, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(9, 2, EngineSchematicPartType.NonSymbol, '.'),

					//......#...
					GenerateEngineSchematicPart(0, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 3, EngineSchematicPartType.Symbol, '#'),
                    GenerateEngineSchematicPart(7, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 3, EngineSchematicPartType.NonSymbol, '.'),

					//617*......
					GenerateEngineSchematicPart(0, 4, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(1, 4, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(2, 4, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(3, 4, EngineSchematicPartType.Symbol, '*'),
                    GenerateEngineSchematicPart(4, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 4, EngineSchematicPartType.NonSymbol, '.'),

					//.....+.58.
					GenerateEngineSchematicPart(0, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 5, EngineSchematicPartType.Symbol, '+'),
                    GenerateEngineSchematicPart(6, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 5, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(8, 5, EngineSchematicPartType.Number, '8'),
                    GenerateEngineSchematicPart(9, 5, EngineSchematicPartType.NonSymbol, '.'),
					
					//..592.....
					GenerateEngineSchematicPart(0, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 6, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(3, 6, EngineSchematicPartType.Number, '9'),
                    GenerateEngineSchematicPart(4, 6, EngineSchematicPartType.Number, '2'),
                    GenerateEngineSchematicPart(5, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 6, EngineSchematicPartType.NonSymbol, '.'),

					//......755.
					GenerateEngineSchematicPart(0, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 7, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(7, 7, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(8, 7, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(9, 7, EngineSchematicPartType.NonSymbol, '.'),

					//...$.*....
					GenerateEngineSchematicPart(0, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 8, EngineSchematicPartType.Symbol, '$'),
                    GenerateEngineSchematicPart(4, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 8, EngineSchematicPartType.Symbol, '*'),
                    GenerateEngineSchematicPart(6, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 8, EngineSchematicPartType.NonSymbol, '.'),

					//.664.598..
					GenerateEngineSchematicPart(0, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 9, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(2, 9, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(3, 9, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(4, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 9, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(6, 9, EngineSchematicPartType.Number, '9'),
                    GenerateEngineSchematicPart(7, 9, EngineSchematicPartType.Number, '8'),
                    GenerateEngineSchematicPart(8, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 9, EngineSchematicPartType.NonSymbol, '.'),
                }
            };
			return engineSchematic;
		}

		public EngineSchematicPart GenerateEngineSchematicPart(int x, int y, EngineSchematicPartType engineSchematicPartType, object value)
		{
			var part = new EngineSchematicPart()
			{
				Position = new Position() { X = x, Y = y },
				EngineSchematicPartType = engineSchematicPartType,
				Value = value
			};
			return part;
		}

		[Fact]
		public void SampleInput_PartTwo_ParsesCorrectly()
		{
			//Arrange
			var inputParser = new DayThreeInputParser();
            var expectedResult = GenerateTestEngineSchematicPartTwo();

            //Act
            var result = inputParser.ParseProblemTwoInput(this.SampleProblemTwoInput);

			//Assert
			Assert.Equal(expectedResult, result);
		}

        public EngineSchematic GenerateTestEngineSchematicPartTwo()
        {
            var engineSchematic = new EngineSchematic()
            {
                Columns = 10,
                Rows = 10,
                Parts = new List<IEngineSchematicPart>()
                {
					//467..114..
                    GenerateEngineSchematicPart(0, 0, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(1, 0, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(2, 0, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(3, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 0, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(6, 0, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(7, 0, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(8, 0, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 0, EngineSchematicPartType.NonSymbol, '.'),

					//...*......
                    GenerateEngineSchematicPart(0, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 1, EngineSchematicPartType.Gear, '*'),
                    GenerateEngineSchematicPart(4, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 1, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 1, EngineSchematicPartType.NonSymbol, '.'),
					
					//..35..633.
                    GenerateEngineSchematicPart(0, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(3, 2, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(4, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 2, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 2, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(7, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(8, 2, EngineSchematicPartType.Number, '3'),
                    GenerateEngineSchematicPart(9, 2, EngineSchematicPartType.NonSymbol, '.'),

					//......#...
					GenerateEngineSchematicPart(0, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 3, EngineSchematicPartType.Symbol, '#'),
                    GenerateEngineSchematicPart(7, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 3, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 3, EngineSchematicPartType.NonSymbol, '.'),

					//617*......
					GenerateEngineSchematicPart(0, 4, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(1, 4, EngineSchematicPartType.Number, '1'),
                    GenerateEngineSchematicPart(2, 4, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(3, 4, EngineSchematicPartType.Gear, '*'),
                    GenerateEngineSchematicPart(4, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 4, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 4, EngineSchematicPartType.NonSymbol, '.'),

					//.....+.58.
					GenerateEngineSchematicPart(0, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 5, EngineSchematicPartType.Symbol, '+'),
                    GenerateEngineSchematicPart(6, 5, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 5, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(8, 5, EngineSchematicPartType.Number, '8'),
                    GenerateEngineSchematicPart(9, 5, EngineSchematicPartType.NonSymbol, '.'),
					
					//..592.....
					GenerateEngineSchematicPart(0, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 6, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(3, 6, EngineSchematicPartType.Number, '9'),
                    GenerateEngineSchematicPart(4, 6, EngineSchematicPartType.Number, '2'),
                    GenerateEngineSchematicPart(5, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 6, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 6, EngineSchematicPartType.NonSymbol, '.'),

					//......755.
					GenerateEngineSchematicPart(0, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(4, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 7, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(6, 7, EngineSchematicPartType.Number, '7'),
                    GenerateEngineSchematicPart(7, 7, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(8, 7, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(9, 7, EngineSchematicPartType.NonSymbol, '.'),

					//...$.*....
					GenerateEngineSchematicPart(0, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(2, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(3, 8, EngineSchematicPartType.Symbol, '$'),
                    GenerateEngineSchematicPart(4, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 8, EngineSchematicPartType.Gear, '*'),
                    GenerateEngineSchematicPart(6, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(7, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(8, 8, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 8, EngineSchematicPartType.NonSymbol, '.'),

					//.664.598..
					GenerateEngineSchematicPart(0, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(1, 9, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(2, 9, EngineSchematicPartType.Number, '6'),
                    GenerateEngineSchematicPart(3, 9, EngineSchematicPartType.Number, '4'),
                    GenerateEngineSchematicPart(4, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(5, 9, EngineSchematicPartType.Number, '5'),
                    GenerateEngineSchematicPart(6, 9, EngineSchematicPartType.Number, '9'),
                    GenerateEngineSchematicPart(7, 9, EngineSchematicPartType.Number, '8'),
                    GenerateEngineSchematicPart(8, 9, EngineSchematicPartType.NonSymbol, '.'),
                    GenerateEngineSchematicPart(9, 9, EngineSchematicPartType.NonSymbol, '.'),
                }
            };
            return engineSchematic;
        }

        [Fact]
		public async Task SampleInput_ProducesCorrectResultForPartOne()
		{
			//Arrange
			var inputParser = new DayThreeInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemOneInput);

			var solver = new DayThreeSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "4361";

			//Act
			var result = await solver.SolvePartOneAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async Task SampleInput_ProducesCorrectResultForPartTwo()
		{
			//Arrange
			var inputParser = new DayThreeInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblemTwoInput);

			var solver = new DayThreeSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "467835";

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
			var inputParser = new DayThreeInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayThreeSolver(problemInputReader, problemOutputReaderMock, inputParser);
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
			var inputParser = new DayThreeInputParser();
			var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
			var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);

			var solver = new DayThreeSolver(problemInputReader, problemOutputReaderMock, inputParser);
			var expectedResult = "";

			//Act
			var result = await solver.SolvePartTwoAsync();

			//Assert
			Assert.Equal(expectedResult, result);
		}
	}
}
