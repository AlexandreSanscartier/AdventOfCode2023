using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Gardens
{
    public interface IGardenAlmanac
    {
        List<long> SeedsThatNeedPlanting { get; }
        List<IGardenMappings> GardenMappings { get; }

        void AddMapping(IGardenMappings mapping);

        void AddSeedToPlant(long seed); // TODO: Add ValueOf for seed

        IGardenMappings GetMappingForSourceType(GardenAlmanacMappingType sourceType);
        IGardenMappings GetMappingForDestinationType(GardenAlmanacMappingType destinationType);
    }
}
