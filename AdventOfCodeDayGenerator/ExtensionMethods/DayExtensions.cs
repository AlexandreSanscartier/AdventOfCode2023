using AdventOfCodeDayGenerator.Models.Interfaces;

namespace AdventOfCodeDayGenerator.ExtensionMethods
{
    public static class DayExtensions
    {
        public static string? ToStringDay(this IDay day)
        {
            return day.Value switch
            {
                1 => "One",
                2 => "Two",
                3 => "Three",
                4 => "Four",
                5 => "Five",
                6 => "Six",
                7 => "Seven",
                8 => "Eight",
                9 => "Nine",
                10 => "Ten",
                11 => "Eleven",
                12 => "Twelve",
                13 => "Thirteen",
                14 => "Fourteen",
                15 => "Fifteen",
                16 => "Sixteen",
                17 => "Seventeen",
                18 => "Eighteen",
                19 => "Nineteen",
                20 => "Twenty",
                21 => "Twentyone",
                22 => "Twentytwo",
                23 => "Twentythree",
                24 => "Tewntyfour",
                25 => "Twentyfive",
                _ => null
            };
        }
    }
}
