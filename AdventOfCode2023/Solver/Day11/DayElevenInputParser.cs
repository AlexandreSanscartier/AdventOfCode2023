using AdventOfCode2023.Models.Maps;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day11

{
	public class DayElevenInputParser : BaseInputParser<GalaxyMap>, IDayElevenInputParser
	{
		public override GalaxyMap Parse(string input)
		{
			var inputParts = input.Split('\n');
			var characterGalaxyMap = new List<List<char>>();
			foreach(var inputPart in inputParts)
			{
				characterGalaxyMap.Add(inputPart.ToCharArray().ToList());
            }

			var galaxyMap = new GalaxyMap(characterGalaxyMap);
			return galaxyMap;
        }
	}
}
