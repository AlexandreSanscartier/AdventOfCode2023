using AdventOfCode2023.Models.Interfaces.Gardens;

namespace AdventOfCode2023.Models.Gardens
{
    public class SeedRange : ISeedRange
    {
        public long SeedStart { get; set; }
        public long Range { get; set; }
    }
}
