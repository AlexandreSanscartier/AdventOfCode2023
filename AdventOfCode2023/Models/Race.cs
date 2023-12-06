using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class Race : IRace
    {
        public long Time { get; set; }
        public long Distance { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Race race &&
                   Time == race.Time &&
                   Distance == race.Distance;
        }
    }
}
