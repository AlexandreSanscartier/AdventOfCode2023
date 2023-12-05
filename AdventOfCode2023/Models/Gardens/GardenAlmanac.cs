using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Models.Gardens
{
    public class GardenAlmanac : IGardenAlmanac
    {
        private List<IGardenMappings> _gardenMappings = new();

        private List<int> _seedsThatNeedPlanting = new();
        public List<IGardenMappings> GardenMappings => _gardenMappings;
        public List<int> SeedsThatNeedPlanting => _seedsThatNeedPlanting;

        public void AddMapping(IGardenMappings mapping)
        {
            this._gardenMappings.Add(mapping);
        }

        public void AddSeedToPlant(int seed)
        {
            this._seedsThatNeedPlanting.Add(seed);
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
    }
}
