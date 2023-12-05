using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Models.Gardens
{
    public class GardenAlmanac : IGardenAlmanac
    {
        private List<IGardenMappings> _gardenMappings = new();

        private List<long> _seedsThatNeedPlanting = new();

        private List<ISeedRange> _seedRange = new();
        public List<IGardenMappings> GardenMappings => _gardenMappings;
        public List<long> SeedsThatNeedPlanting => _seedsThatNeedPlanting;

        public List<ISeedRange> SeedRange => _seedRange;

        public void AddMapping(IGardenMappings mapping)
        {
            this._gardenMappings.Add(mapping);
        }

        public void AddSeedToPlant(long seed)
        {
            this._seedsThatNeedPlanting.Add(seed);
        }

        public void AddSeedRange(ISeedRange seedRange)
        {
            this._seedRange.Add(seedRange);
        }

        public IGardenMappings GetMappingForDestinationType(GardenAlmanacMappingType destinationType)
        {
            return this.GardenMappings.Where(x => x.DestinationType == destinationType).Single();
        }

        public IGardenMappings GetMappingForSourceType(GardenAlmanacMappingType sourceType)
        {
            return this.GardenMappings.Where(x => x.SourceType == sourceType).Single();
        }

        public override bool Equals(object? obj)
        {
            return obj is GardenAlmanac gardenAlmanac &&
                this.GardenMappings.Count == gardenAlmanac.GardenMappings.Count &&
                this.GardenMappings.All(x => gardenAlmanac.GardenMappings.Contains(x)) &&
                this.SeedsThatNeedPlanting.Count == gardenAlmanac.SeedsThatNeedPlanting.Count &&
                this.SeedsThatNeedPlanting.All(x => gardenAlmanac.SeedsThatNeedPlanting.Contains(x));
        }

        public bool IsInSeedRange(long seed)
        {
            return this.SeedRange.Any(x => seed >= x.SeedStart && seed <= x.SeedStart + x.Range);
        }
    }
}
