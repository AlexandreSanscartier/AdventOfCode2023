using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Gardens
{
    public interface IGardenMapping
    {
        int DestinationRangeStart { get; set; }

        int SourceRangeStart { get; set; }

        int RangeLength { get; set; }
    }
}
