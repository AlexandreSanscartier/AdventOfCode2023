using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Models.Gardens
{
    public class GardenMappings : IGardenMappings
    {
        public GardenAlmanacMappingType SourceType { get; set; }
        public GardenAlmanacMappingType DestinationType { get; set; }
        public List<IGardenMapping> Mappings { get; set; }

        public void AddMapping(IGardenMapping mapping)
        {
            this.Mappings.Add(mapping);
        }

        public override bool Equals(object? obj)
        {
            return obj is GardenMappings mappings &&
                SourceType == mappings.SourceType &&
                DestinationType == mappings.DestinationType &&
                Mappings.Count == mappings.Mappings.Count &&
                Mappings.All(x => mappings.Mappings.Contains(x));
        }

        public long MapFromSourceToDestination(long sourceInt)
        {
            foreach(var mapping in Mappings)
            {
                var start = mapping.SourceRangeStart;
                var end = mapping.SourceRangeStart + mapping.RangeLength - 1;
                if(sourceInt >= start && sourceInt <= end)
                {
                    var index = sourceInt - start;
                    return mapping.DestinationRangeStart + index;
                }
            }
            return sourceInt;
        }
    }
}
