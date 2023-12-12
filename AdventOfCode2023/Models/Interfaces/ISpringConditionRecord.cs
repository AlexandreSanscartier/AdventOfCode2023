namespace AdventOfCode2023.Models.Interfaces
{
    public interface ISpringConditionRecord
    {
        string Pattern { get; set; }

        List<int> SizeOfContiguousGroups { get; set; }
    }
}
