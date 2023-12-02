using AdventOfCodeDayGenerator.Models.Interfaces;
using System.Text;

namespace AdventOfCodeDayGenerator.Models
{
    public class SolverGeneratorConfigurationModel : ISolverGeneratorConfigurationModel
    {
        public int Day { get; set; }
        public string? InputParserModelNamespace { get; set; }
        public string InputParserClassName { get; set; } = null!;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Day: {Day}");
            stringBuilder.AppendLine($"Namespace: {InputParserModelNamespace}");
            stringBuilder.AppendLine($"Class: {InputParserClassName}");
            return stringBuilder.ToString();
        }
    }
}
