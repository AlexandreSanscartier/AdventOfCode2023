using AdventOfCodeDayGenerator.Models.Interfaces;
using ValueOf;

namespace AdventOfCodeDayGenerator.Models
{
    public class Day : ValueOf<int, Day>, IDay
    {
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
