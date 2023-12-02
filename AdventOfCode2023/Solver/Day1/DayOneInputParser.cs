using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day1

{
	public class DayOneInputParser : BaseInputParser<List<int>>, IDayOneInputParser
	{
        public override List<int> ParseProblemTwoInput(string input)
        {
            var calibrationValues = new List<int>();

            foreach (var stringInput in input.Split('\n'))
            {
                var newString = string.Empty;
                foreach (var characterFromString in stringInput)
                {
                    newString += characterFromString;
                    newString = newString.Replace("one", "1ne");
                    newString = newString.Replace("two", "2wo");
                    newString = newString.Replace("three", "3hree");
                    newString = newString.Replace("four", "4our");
                    newString = newString.Replace("five", "5ive");
                    newString = newString.Replace("six", "6ix");
                    newString = newString.Replace("seven", "7even");
                    newString = newString.Replace("eight", "8ight");
                    newString = newString.Replace("nine", "9ine");
                }
                calibrationValues.Add(ParseNumbers(newString));
            }

            return calibrationValues;
        }

        public override List<int> Parse(string input)
		{
			var calibrationValues = new List<int>();

            foreach(var stringInput in input.Split('\n'))
            {
                calibrationValues.Add(ParseNumbers(stringInput));
            }

            return calibrationValues;
        }

        private int ParseNumbers(string value)
        {
            var firstNumber = 0;
            var secondNumber = 0;
            foreach (var v in value.ToCharArray())
            {
                if (int.TryParse($"{v}", out firstNumber))
                {
                    break;
                }
            }

            foreach (var v in value.ToCharArray().Reverse())
            {
                if (int.TryParse($"{v}", out secondNumber))
                {
                    break;
                }
            }

            var returnValue = 0;
            int.TryParse($"{firstNumber}{secondNumber}", out returnValue);
            return returnValue;
        }
    }
}
