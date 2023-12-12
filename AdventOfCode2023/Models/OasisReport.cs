using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class OasisReport : IOasisReport
    {
        public List<long> ValueHistory { get; set; } = new();

        public override bool Equals(object? obj)
        {
            return obj is OasisReport report &&
                    report.ValueHistory.Count() == ValueHistory.Count() &&
                    report.ValueHistory.All(x => ValueHistory.Contains(x));
        }
    }
}
