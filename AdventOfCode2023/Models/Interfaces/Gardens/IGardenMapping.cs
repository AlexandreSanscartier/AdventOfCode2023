using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Gardens
{
    public interface IGardenMapping
    {
        long DestinationRangeStart { get; set; }

        long SourceRangeStart { get; set; }

        long RangeLength { get; set; }
    }
}
