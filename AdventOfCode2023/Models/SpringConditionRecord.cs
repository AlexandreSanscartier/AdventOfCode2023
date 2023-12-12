using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class SpringConditionRecord : ISpringConditionRecord
    {
        public string Pattern { get; set; }
        public List<int> SizeOfContiguousGroups { get; set; } = new();

        public override bool Equals(object? obj)
        {
            return obj is SpringConditionRecord record &&
                   Pattern.Equals(record.Pattern) &&
                SizeOfContiguousGroups.Count == record.SizeOfContiguousGroups.Count &&
                SizeOfContiguousGroups.All(x => record.SizeOfContiguousGroups.Contains(x));
        }
    }
}
