using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Gardens
{
    public interface IGardenMappings
    {
        GardenAlmanacMappingType SourceType { get; set; }

        GardenAlmanacMappingType DestinationType { get; set; }

        List<IGardenMapping> Mappings { get; set; }

        void AddMapping(IGardenMapping mapping);

        long MapFromSourceToDestination(long sourceInt);
    }
}
