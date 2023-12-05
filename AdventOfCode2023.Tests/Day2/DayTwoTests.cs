using AdventOfCodeClient.interfaces;
using AdventOfCodeTest.Library.Helpers;
using AdventOfCodeTest.Library.Interfaces;
using AdventOfCode2023.Solver.day2;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Tests
{
    public class DayTwoTests : ISolverFactTests
    {
        private readonly int _day = 2;
        private readonly string _sampleProblemInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        private readonly string? _sampleProblemOneInput = null;
        private readonly string? _sampleProblemTwoInput = null;

        public int Day => _day;

        public string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;
        public string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;

        [Fact]
        public void SampleInput_PartOne_ParsesCorrectly()
        {
            //Arrange
            var inputParser = new DayTwoInputParser();
            var expectedResult = GenerateGameForSampleInputOne();

            //Act
            var result = inputParser.ParseProblemOneInput(SampleProblemOneInput);

            //Assert
            Assert.Equal(expectedResult.First(), result.First());
        }

        private IEnumerable<CubeGame> GenerateGameForSampleInputOne()
        {
            var cubeGames = new List<CubeGame>();
            var cubeGameOne = new CubeGame();
            cubeGameOne.Id = 1;
            cubeGameOne.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("blue"), 3 },
                    { Cube.From("red"), 4 },
                }
            });
            cubeGameOne.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("red"), 1 },
                    { Cube.From("green"), 2 },
                    { Cube.From("blue"), 6 },
                }
            });
            cubeGameOne.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 2 },
                }
            });

            cubeGames.Add(cubeGameOne);

            var cubeGameTwo = new CubeGame();
            cubeGameTwo.Id = 2;
            cubeGameTwo.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("blue"), 1 },
                    { Cube.From("green"), 2 },
                }
            });
            cubeGameTwo.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 3 },
                    { Cube.From("blue"), 4 },
                    { Cube.From("red"), 1 },
                }
            });
            cubeGameTwo.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 1 },
                    { Cube.From("blue"), 1 },
                }
            });

            cubeGames.Add(cubeGameTwo);

            var cubeGameThree = new CubeGame();
            cubeGameThree.Id = 3;
            cubeGameThree.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 8 },
                    { Cube.From("blue"), 6 },
                    { Cube.From("red"), 20 },
                }
            });
            cubeGameThree.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("blue"), 5 },
                    { Cube.From("red"), 4 },
                    { Cube.From("green"), 13 },
                }
            });
            cubeGameThree.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 5 },
                    { Cube.From("red"), 1 },
                }
            });

            cubeGames.Add(cubeGameThree);

            var cubeGameFour = new CubeGame();
            cubeGameFour.Id = 4;
            cubeGameFour.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 1 },
                    { Cube.From("red"), 3 },
                    { Cube.From("blue"), 6 },
                }
            });
            cubeGameFour.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 3 },
                    { Cube.From("red"), 6 },
                }
            });
            cubeGameFour.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("green"), 3 },
                    { Cube.From("blue"), 15 },
                    { Cube.From("red"), 14 },
                }
            });

            cubeGames.Add(cubeGameFour);

            var cubeGameFive = new CubeGame();
            cubeGameFive.Id = 5;
            cubeGameFive.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("red"), 6 },
                    { Cube.From("blue"), 1 },
                    { Cube.From("green"), 3 },
                }
            });
            cubeGameFive.AddRound(new CubeGameRound()
            {
                RevealedCubes = new Dictionary<Cube, int>()
                {
                    { Cube.From("blue"), 2 },
                    { Cube.From("red"), 1 },
                    { Cube.From("green"), 2 },
                }
            });

            cubeGames.Add(cubeGameFive);

            return cubeGames;
        }

        [Fact]
        public void SampleInput_PartTwo_ParsesCorrectly()
        {
            //Arrange
            var inputParser = new DayTwoInputParser();
            var expectedResult = GenerateGameForSampleInputOne();

            //Act
            var result = inputParser.ParseProblemTwoInput(SampleProblemTwoInput);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SampleInput_ProducesCorrectResultForPartOne()
        {
            //Arrange
            var inputParser = new DayTwoInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(Day, SampleProblemOneInput);

            var solver = new DayTwoSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "8";

            //Act
            var result = await solver.SolvePartOneAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SampleInput_ProducesCorrectResultForPartTwo()
        {
            //Arrange
            var inputParser = new DayTwoInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(Day, SampleProblemTwoInput);

            var solver = new DayTwoSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "2286";

            //Act
            var result = await solver.SolvePartTwoAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PartOne_ProducesCorrectResult()
        {
            //Arrange
            var problemInput = InputFileReaderHelper.ReadFile(Day);
            var inputParser = new DayTwoInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(Day, problemInput);

            var solver = new DayTwoSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "2528";

            //Act
            var result = await solver.SolvePartOneAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PartTwo_ProducesCorrectResult()
        {
            //Arrange
            var problemInput = InputFileReaderHelper.ReadFile(Day);
            var inputParser = new DayTwoInputParser();
            var problemOutputReaderMock = A.Fake<IProblemOutputSender>();
            var problemInputReader = InputReaderMockerHelper.CreateMock(Day, problemInput);

            var solver = new DayTwoSolver(problemInputReader, problemOutputReaderMock, inputParser);
            var expectedResult = "67363";

            //Act
            var result = await solver.SolvePartTwoAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
