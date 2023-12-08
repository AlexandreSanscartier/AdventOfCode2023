using AdventOfCode2023.ExtensionMethods;
using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Maps;
using AdventOfCode2023.Models.Maps.Interfaces;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day8

{
	public class DayEightInputParser : BaseInputParser<MapInstruction>, IDayEightInputParser
	{
		public override MapInstruction Parse(string input)
		{
			var inputParts = input.Split('\n').Where(x => !string.IsNullOrEmpty(x));

			var createdNodesDictionary = new Dictionary<string, IMapNode>();
			IMapNode? firstNode = null;

			var directions = ParseDirectionsFromString(inputParts.First().Trim());

			foreach(var nodeString in  inputParts.Skip(1)) 
			{
				var nodes = nodeString.Replace(" = ", ",").Split(",");
				var rootNode = nodes[0].Trim();
				var leftNode = nodes[1].Replace("(", "").Trim();
				var rightNode = nodes[2].Replace(")", "").Trim();

				IMapNode? rootMapNode = null;
				IMapNode? leftMapNode = null;
				IMapNode? rightMapNode = null;

                if (!createdNodesDictionary.ContainsKey(rootNode))
				{
					rootMapNode = new MapNode(rootNode);
                    createdNodesDictionary.Add(rootNode, rootMapNode);
                } 
				else
				{
					rootMapNode = createdNodesDictionary[rootNode];
                }

                if (!createdNodesDictionary.ContainsKey(leftNode))
                {
                    leftMapNode = new MapNode(leftNode);
					createdNodesDictionary.Add(leftNode, leftMapNode);
                }
				else
				{
                    leftMapNode = createdNodesDictionary[leftNode];
                }

                if (!createdNodesDictionary.ContainsKey(rightNode))
                {
					rightMapNode = new MapNode(rightNode);
                    createdNodesDictionary.Add(rightNode, rightMapNode);
                }
				else
				{
                    rightMapNode = createdNodesDictionary[rightNode];
                }

				rootMapNode.LeftDestination = leftMapNode;
				rootMapNode.RightDestination = rightMapNode;

				if (firstNode == null)
					firstNode = rootMapNode;
            }

			return new MapInstruction()
			{
				Directions = directions,
				StartingNodes = new List<IMapNode>() { createdNodesDictionary["AAA"] }
            };
		}

        public override MapInstruction ParseProblemTwoInput(string input)
        {
            var inputParts = input.Split('\n').Where(x => !string.IsNullOrEmpty(x));

            var createdNodesDictionary = new Dictionary<string, IMapNode>();
            IMapNode? firstNode = null;

            var directions = ParseDirectionsFromString(inputParts.First().Trim());

            foreach (var nodeString in inputParts.Skip(1))
            {
                var nodes = nodeString.Replace(" = ", ",").Split(",");
                var rootNode = nodes[0].Trim();
                var leftNode = nodes[1].Replace("(", "").Trim();
                var rightNode = nodes[2].Replace(")", "").Trim();

                IMapNode? rootMapNode = null;
                IMapNode? leftMapNode = null;
                IMapNode? rightMapNode = null;

                if (!createdNodesDictionary.ContainsKey(rootNode))
                {
                    rootMapNode = new MapNode(rootNode);
                    createdNodesDictionary.Add(rootNode, rootMapNode);
                }
                else
                {
                    rootMapNode = createdNodesDictionary[rootNode];
                }

                if (!createdNodesDictionary.ContainsKey(leftNode))
                {
                    leftMapNode = new MapNode(leftNode);
                    createdNodesDictionary.Add(leftNode, leftMapNode);
                }
                else
                {
                    leftMapNode = createdNodesDictionary[leftNode];
                }

                if (!createdNodesDictionary.ContainsKey(rightNode))
                {
                    rightMapNode = new MapNode(rightNode);
                    createdNodesDictionary.Add(rightNode, rightMapNode);
                }
                else
                {
                    rightMapNode = createdNodesDictionary[rightNode];
                }

                rootMapNode.LeftDestination = leftMapNode;
                rootMapNode.RightDestination = rightMapNode;

                if (firstNode == null)
                    firstNode = rootMapNode;
            }

            var startingNodes = createdNodesDictionary.GetValueListByKeyFilter(x => x.EndsWith("A"));

            return new MapInstruction()
            {
                Directions = directions,
                StartingNodes = startingNodes.ToList()
            };
        }



        private List<MapDirectionType> ParseDirectionsFromString(string input)
		{
			var mapDirections = new List<MapDirectionType>();
			foreach(var character in input)
			{
				if(character.Equals('L'))
				{
					mapDirections.Add(MapDirectionType.Left);
                }
				if (character.Equals('R'))
				{
                    mapDirections.Add(MapDirectionType.Right);
                }
			}
			return mapDirections;

        }
    }
}
