using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models.Maps;
using AdventOfCode2023.Models.Maps.Interfaces;
using AdventOfCode2023.ExtensionMethods;

namespace AdventOfCode2023.Solver.day8
{
	public class DayEightSolver : BaseSolver<MapInstruction>
	{
		public DayEightSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayEightInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 8;

		public override string SolvePartOne(MapInstruction input)
		{
			var destination = "ZZZ";
			IMapNode currentNode = input.StartingNodes.First();
			var currentDirectionIndex = 0;
			var numberOfSteps = 0l;

			do
			{
				var currentDirection = input.Directions[currentDirectionIndex];
				if(currentDirection == Models.Enum.MapDirectionType.Left)
				{
					currentNode = currentNode.LeftDestination;
				}
                if (currentDirection == Models.Enum.MapDirectionType.Right)
                {
                    currentNode = currentNode.RightDestination;
                }
                currentDirectionIndex++;
				numberOfSteps++;
                if (currentDirectionIndex >= input.Directions.Count) currentDirectionIndex = 0;
            } while (!currentNode.NodeRepresentation.Equals(destination));

			return numberOfSteps.ToString();
        }

		public override string SolvePartTwo(MapInstruction input)
		{
            var currentNodes = input.StartingNodes;
            var currentDirectionIndex = 0;
            var numberOfSteps = 0L;

            var stepsToZ = new ulong[6] {0,0,0,0,0,0};

            do
            {
                var currentDirection = input.Directions[currentDirectionIndex];
                for (int i = 0; i < currentNodes.Count(); i++)
                {
                    if (currentDirection == Models.Enum.MapDirectionType.Left)
                    {
                        currentNodes[i] = currentNodes[i].LeftDestination;
                    }
                    if (currentDirection == Models.Enum.MapDirectionType.Right)
                    {
                        currentNodes[i] = currentNodes[i].RightDestination;
                    }
                    if (currentNodes[i].NodeRepresentation.EndsWith("Z"))
                    {
                        if (stepsToZ[i] == 0)
                            stepsToZ[i] = (ulong)numberOfSteps+1;
                    }
                }

                if (stepsToZ.All(x => x != 0)) {
                    Console.WriteLine(string.Join(',', stepsToZ));
                    var answer = stepsToZ.Aggregate((S, val) => (S * val) / gcd(S, val));
                    Console.WriteLine(answer);
                    Environment.Exit(0);
                }

                currentDirectionIndex++;
                numberOfSteps++;
                if (currentDirectionIndex >= input.Directions.Count) currentDirectionIndex = 0;
            } while (currentNodes.Any(x => !x.NodeRepresentation.EndsWith("Z")));

            return numberOfSteps.ToString();
        }

        private ulong gcd(ulong first, ulong second)
        {
            if(second == 0) return (ulong)first;
            else
            {
                return gcd(second, first % second);
            }
        }
	}
}
