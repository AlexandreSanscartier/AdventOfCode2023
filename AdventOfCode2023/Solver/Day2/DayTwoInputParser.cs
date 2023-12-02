using AdventOfCode2023.Models;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day2

{
	public class DayTwoInputParser : BaseInputParser<List<CubeGame>>, IDayTwoInputParser
	{
		public override List<CubeGame> Parse(string input)
		{
			var splitInput = input.Split('\n');

			var cubeGames = new List<CubeGame>();


			foreach(var gameInput in splitInput)
			{
				var splitGameParts = gameInput.Split(":");
				var cubeGame = new CubeGame();
				cubeGame.Id = int.Parse(splitGameParts[0].Split(" ")[1]);

				var rounds = splitGameParts[1].Split(';');
				foreach(var round in rounds)
				{
					var cubeGameRound = new CubeGameRound();
					var cubes = round.Split(",");
					foreach(var cube in cubes)
					{
						var cubeParts = cube.Trim().Split(" ");
						var cubeAmount = int.Parse(cubeParts.First());
						var cubeColor = cubeParts.Last().Trim();
						cubeGameRound.AddCube(Cube.From(cubeColor), cubeAmount);
                    }
					cubeGame.AddRound(cubeGameRound);
				}
                cubeGames.Add(cubeGame);
			}

			return cubeGames;
        }
	}
}
