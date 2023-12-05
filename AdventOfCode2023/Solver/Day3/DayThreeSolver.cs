using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Engine;
using AdventOfCode2023.Models.Interfaces.Engine;
using AdventOfCode2023.Models;
using AdventOfCode2023.Models.Interfaces;
using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Solver.day3
{
	public class DayThreeSolver : BaseSolver<EngineSchematic>
	{
		public DayThreeSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayThreeInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 3;

		public override string SolvePartOne(EngineSchematic input)
		{
			var partNumberList = new List<int>();
			var currentNumberString = string.Empty;
			var isNumberAdjacentToSymbol = false;
			foreach(var enginePart in input.Parts)
			{
				if(enginePart.EngineSchematicPartType == EngineSchematicPartType.Number)
				{
					currentNumberString += enginePart.Value;
                    if (HasAdjacentSymbol(input, enginePart.Position))
					{
						isNumberAdjacentToSymbol = true;
					}
				}
				else
				{
					if(!string.IsNullOrEmpty(currentNumberString))
					{
						if(isNumberAdjacentToSymbol)
							partNumberList.Add(int.Parse(currentNumberString));
						isNumberAdjacentToSymbol = false;
						currentNumberString = string.Empty;
					}
				}
			}

            if(!string.IsNullOrEmpty(currentNumberString))
            {
                if (isNumberAdjacentToSymbol)
                    partNumberList.Add(int.Parse(currentNumberString));
            }

			return partNumberList.Sum().ToString();
		}

		public override string SolvePartTwo(EngineSchematic input)
		{
			var gearRatio = new Dictionary<IPosition, List<int>>();
            var adjacentGears = new List<IPosition>();
            var currentNumberString = string.Empty;
            foreach (var enginePart in input.Parts)
            {
                if (enginePart.EngineSchematicPartType == EngineSchematicPartType.Number)
                {
                    currentNumberString += enginePart.Value;
                    if (HasAdjacentGear(input, enginePart.Position))
                    {
                        adjacentGears = this.GetAllAdjacentGearPositions(input, enginePart.Position).Distinct().ToList();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentNumberString))
                    {
                        if (adjacentGears.Any())
                        {
                            foreach(var gearPosition in adjacentGears)
                            {
                                if(!gearRatio.ContainsKey(gearPosition))
                                {
                                    gearRatio.Add(gearPosition, new List<int>() { int.Parse(currentNumberString) });
                                } else
                                {
                                    gearRatio[gearPosition].Add(int.Parse(currentNumberString));
                                }
                            }
                        }

                        adjacentGears = new List<IPosition>();
                        currentNumberString = string.Empty;
                    }
                }
            }

            var only2NumbersInGears = gearRatio.Values.Where(x => x.Count == 2);
            var result = 0;
            foreach(var only2NumbersInGear in only2NumbersInGears)
            {
                result += (only2NumbersInGear[0] * only2NumbersInGear[1]);
            }

            return result.ToString();

        }

        private List<IPosition> GetAllAdjacentGearPositions(IEngineSchematic engineSchematic, IPosition position)
        {
            var gearPositions = new List<IPosition>();
            var topLeftPosition = new Position(-1, -1).Add(position);
            var topMiddlePosition = new Position(0, -1).Add(position);
            var topRightPosition = new Position(-1, 1).Add(position);
            var MiddleLeftPosition = new Position(-1, 0).Add(position);
            var MiddleRightPosition = new Position(1, 0).Add(position);
            var bottomLeftPosition = new Position(1, -1).Add(position);
            var bottomMiddlePosition = new Position(0, 1).Add(position);
            var bottomRightPosition = new Position(1, 1).Add(position);

            var topLeftPart = engineSchematic.GetPartAtPosition(topLeftPosition);
            var topMiddlePart = engineSchematic.GetPartAtPosition(topMiddlePosition);
            var topRightPart = engineSchematic.GetPartAtPosition(topRightPosition);
            var middleLeftPart = engineSchematic.GetPartAtPosition(MiddleLeftPosition);
            var middleRightPart = engineSchematic.GetPartAtPosition(MiddleRightPosition);
            var bottomLeftPart = engineSchematic.GetPartAtPosition(bottomLeftPosition);
            var bottomMiddlePart = engineSchematic.GetPartAtPosition(bottomMiddlePosition);
            var bottomRightPart = engineSchematic.GetPartAtPosition(bottomRightPosition);

            var parts = new List<IEngineSchematicPart?>()
            {
                topLeftPart, topMiddlePart, topRightPart,
                middleLeftPart, middleRightPart,
                bottomLeftPart, bottomMiddlePart, bottomRightPart,
            };

            foreach(var part in parts)
            {
                if (IsPartType(part, EngineSchematicPartType.Gear))
                    gearPositions.Add(part.Position);
            }
            return gearPositions;
        }

		private bool HasAdjacentPartType(IEngineSchematic engineSchematic, IPosition position, EngineSchematicPartType engineSchematicPartType)
		{
            /*
 *	            [(-1,-1)][( 0,-1)][(-1, 1)]
 *	            [(-1, 0)][( 0, 0)][( 1, 0)]
 *	            [( 1,-1)][( 0, 1)][( 1, 1)]
 */
            var topLeftPosition = new Position(-1, -1).Add(position);
            var topMiddlePosition = new Position(0, -1).Add(position);
            var topRightPosition = new Position(-1, 1).Add(position);
            var MiddleLeftPosition = new Position(-1, 0).Add(position);
            var MiddleRightPosition = new Position(1, 0).Add(position);
            var bottomLeftPosition = new Position(1, -1).Add(position);
            var bottomMiddlePosition = new Position(0, 1).Add(position);
            var bottomRightPosition = new Position(1, 1).Add(position);

            var topLeftPart = engineSchematic.GetPartAtPosition(topLeftPosition);
            var topMiddlePart = engineSchematic.GetPartAtPosition(topMiddlePosition);
            var topRightPart = engineSchematic.GetPartAtPosition(topRightPosition);
            var middleLeftPart = engineSchematic.GetPartAtPosition(MiddleLeftPosition);
            var middleRightPart = engineSchematic.GetPartAtPosition(MiddleRightPosition);
            var bottomLeftPart = engineSchematic.GetPartAtPosition(bottomLeftPosition);
            var bottomMiddlePart = engineSchematic.GetPartAtPosition(bottomMiddlePosition);
            var bottomRightPart = engineSchematic.GetPartAtPosition(bottomRightPosition);

            var parts = new List<IEngineSchematicPart?>()
            {
                topLeftPart, topMiddlePart, topRightPart,
                middleLeftPart, middleRightPart,
                bottomLeftPart, bottomMiddlePart, bottomRightPart,
            };

            return parts.Any(x => IsPartType(x, engineSchematicPartType));
        }

        private bool HasAdjacentSymbol(IEngineSchematic engineSchematic, IPosition position)
		{
            return HasAdjacentPartType(engineSchematic, position, EngineSchematicPartType.Symbol);
        }

        private bool HasAdjacentGear(IEngineSchematic engineSchematic, IPosition position)
        {
            return HasAdjacentPartType(engineSchematic, position, EngineSchematicPartType.Gear);
        }

        private bool IsPartType(IEngineSchematicPart? engineSchematicPart, EngineSchematicPartType engineSchematicPartType)
		{
			if (engineSchematicPart is null) return false;
			return engineSchematicPart.EngineSchematicPartType == engineSchematicPartType;
		}
	}
}
