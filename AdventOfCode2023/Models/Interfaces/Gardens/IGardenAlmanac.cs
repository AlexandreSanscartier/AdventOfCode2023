using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Gardens
{
    public interface IGardenAlmanac
    {
        List<long> SeedsThatNeedPlanting { get; }
        List<IGardenMappings> GardenMappings { get; }

        List<ISeedRange> SeedRange { get; }

        void AddMapping(IGardenMappings mapping);

        void AddSeedToPlant(long seed); // TODO: Add ValueOf for seed

        void AddSeedRange(ISeedRange seedRange);

        IGardenMappings GetMappingForSourceType(GardenAlmanacMappingType sourceType);
        IGardenMappings GetMappingForDestinationType(GardenAlmanacMappingType destinationType);

        bool IsInSeedRange(long seed);
    }
}
