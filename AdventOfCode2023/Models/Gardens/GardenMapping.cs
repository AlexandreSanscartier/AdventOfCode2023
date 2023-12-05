using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Models.Gardens
{
    public class GardenMapping : IGardenMapping
    {
        public int DestinationRangeStart { get; set; }
        public int SourceRangeStart { get; set; }
        public int RangeLength { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GardenMapping mapping &&
                   DestinationRangeStart == mapping.DestinationRangeStart &&
                   SourceRangeStart == mapping.SourceRangeStart &&
                   RangeLength == mapping.RangeLength;
        }
    }
}
