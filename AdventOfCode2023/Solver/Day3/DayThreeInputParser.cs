using AdventOfCode2023.Models;
using AdventOfCode2023.Models.Engine;
using AdventOfCode2023.Models.Enum;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day3

{
	public class DayThreeInputParser : BaseInputParser<EngineSchematic>, IDayThreeInputParser
	{
		public override EngineSchematic Parse(string input)
		{
			var inputParts = input.Split('\n');

            var row = 0;
            var col = 0;
            var engineSchematic = new EngineSchematic();
            foreach (var inputPart in inputParts)
			{
				col = 0;
				foreach(var charPart in inputPart.ToCharArray())
				{
					
					var engineSchematicPart = new EngineSchematicPart()
					{
						Value = charPart,
						Position = new Position()
						{
							X = col,
							Y = row
						},
						EngineSchematicPartType = GetSchematicPartType(charPart)
                    };
					engineSchematic.Parts.Add(engineSchematicPart);
					col++;
				}
				row++;
			}
			engineSchematic.Rows = row;
			engineSchematic.Columns = col;
			return engineSchematic;
		}

        public override EngineSchematic ParseProblemTwoInput(string input)
        {
            var inputParts = input.Split('\n');

            var row = 0;
            var col = 0;
            var engineSchematic = new EngineSchematic();
            foreach (var inputPart in inputParts)
            {
                col = 0;
                foreach (var charPart in inputPart.ToCharArray())
                {

                    var engineSchematicPart = new EngineSchematicPart()
                    {
                        Value = charPart,
                        Position = new Position()
                        {
                            X = col,
                            Y = row
                        },
                        EngineSchematicPartType = GetSchematicForPartTwo(charPart)
                    };
                    engineSchematic.Parts.Add(engineSchematicPart);
                    col++;
                }
                row++;
            }
            engineSchematic.Rows = row;
            engineSchematic.Columns = col;
            return engineSchematic;
        }

        private EngineSchematicPartType GetSchematicForPartTwo(char input)
        {
            var isInt = int.TryParse($"{input}", out _);
            if (isInt) return EngineSchematicPartType.Number;
            if (input == '.') return EngineSchematicPartType.NonSymbol;
            if (input == '*') return EngineSchematicPartType.Gear;
            return EngineSchematicPartType.Symbol;
        }

        private EngineSchematicPartType GetSchematicPartType(char input)
		{
			var isInt = int.TryParse($"{input}", out _);
			if (isInt) return EngineSchematicPartType.Number;
			if (input == '.') return EngineSchematicPartType.NonSymbol;
			return EngineSchematicPartType.Symbol;
		}
	}
}
