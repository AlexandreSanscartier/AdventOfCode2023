using AdventOfCode2023.Models;
using AdventOfCodeClient.Parsers;
using System.Collections.Generic;

namespace AdventOfCode2023.Solver.day12

{
	public class DayTwelveInputParser : BaseInputParser<List<SpringConditionRecord>>, IDayTwelveInputParser
	{
		public override List<SpringConditionRecord> Parse(string input)
		{
			var inputParts = input.Split('\n');
			List<SpringConditionRecord> springConditionRecords = new();
            foreach (var inputPart in inputParts)
			{
				SpringConditionRecord springConditionRecord = new();

                var recordParts = inputPart.Split(' ');
                springConditionRecord.Pattern = recordParts[0];
				recordParts[1].Split(',').ToList().ForEach(x => springConditionRecord.SizeOfContiguousGroups.Add(int.Parse(x)));

				springConditionRecords.Add(springConditionRecord);
            }
			return springConditionRecords;
		}
	}
}
