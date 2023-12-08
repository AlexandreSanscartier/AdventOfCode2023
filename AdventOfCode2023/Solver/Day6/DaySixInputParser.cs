using AdventOfCode2023.Models;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day6

{
	public class DaySixInputParser : BaseInputParser<List<Race>>, IDaySixInputParser
	{
		public override List<Race> Parse(string input)
		{
			var inputParts = input.Split('\n');

			var timeParts = inputParts[0].Split(':')[1].Trim();
			var distanceParts = inputParts[1].Split(':')[1].Trim();

			var times = timeParts.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
			var distances = distanceParts.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();

			var races = new List<Race>();

			for(var i = 0; i < times.Count(); i++)
			{
				races.Add(new Race()
				{
					Distance = distances[i],
					Time = times[i]
				});
			}

			return races;
        }

        public override List<Race> ParseProblemTwoInput(string input)
        {
            var inputParts = input.Split('\n');

            var timeParts = inputParts[0].Split(':')[1].Trim();
            var distanceParts = inputParts[1].Split(':')[1].Trim();

            var time = long.Parse(string.Join("", timeParts.Split(' ').Where(x => !string.IsNullOrEmpty(x))));
            var distance = long.Parse(string.Join("", distanceParts.Split(' ').Where(x => !string.IsNullOrEmpty(x))));

			var races = new List<Race>()
			{
				new Race()
				{
					Distance = distance,
					Time = time
				}
			};

            return races;
        }
    }
}
