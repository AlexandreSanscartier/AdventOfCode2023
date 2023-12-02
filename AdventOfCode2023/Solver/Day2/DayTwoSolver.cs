using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;
using AdventOfCode2023.Exceptions;
using AdventOfCode2023.ExtensionMethods;

namespace AdventOfCode2023.Solver.day2
{
	public class DayTwoSolver : BaseSolver<List<CubeGame>>
	{
		public DayTwoSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayTwoInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 2;

		public override string SolvePartOne(List<CubeGame> input)
		{
			var sum = 0;
			var maxCubeDictionary = new CubeGameRound()
			{
				RevealedCubes = new Dictionary<Cube, int>()
				{
					{ Cube.From("red"), 12 },
					{ Cube.From("green"), 13 },
					{ Cube.From("blue"), 14 },
				}
			};

			foreach(var cubeGame in input)
			{
				var isGamePossible = IsGamePossible(cubeGame, maxCubeDictionary);
				if(isGamePossible)
				{
					sum += cubeGame.Id;
				}
            }

			return sum.ToString();
		}

		public override string SolvePartTwo(List<CubeGame> input)
		{
			var powerCubes = new List<int>();

			foreach (var cubeGame in input)
			{
				var cubeDictionary = new Dictionary<Cube, int>()
				{
					{ Cube.From("red"), int.MinValue },
					{ Cube.From("blue"), int.MinValue },
					{ Cube.From("green"), int.MinValue }
				};

                foreach (var gameRound in  cubeGame.Rounds)
				{
					foreach(var shownCube in gameRound.RevealedCubes)
					{
						var currentValue = cubeDictionary[shownCube.Key];
						if (shownCube.Value > currentValue)
							cubeDictionary[shownCube.Key] = shownCube.Value;
                    }
				}
				powerCubes.Add(cubeDictionary.Values.ToList().Multiply());
            }

			return powerCubes.Sum().ToString();
		}

		private bool IsGamePossible(CubeGame game, CubeGameRound comparer)
		{
			foreach(var gameRound in game.Rounds)
			{
				foreach(var shownCube in gameRound.RevealedCubes)
				{
					if (comparer.RevealedCubes[shownCube.Key] < shownCube.Value)
						return false;
                }
			}
			return true;
		}
	}
}
