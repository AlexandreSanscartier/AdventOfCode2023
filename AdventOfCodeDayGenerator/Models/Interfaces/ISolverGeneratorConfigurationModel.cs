namespace AdventOfCodeDayGenerator.Models.Interfaces
{
    public interface ISolverGeneratorConfigurationModel
    {
        int Day { get; set; }

        string? InputParserModelNamespace { get; set; }

        string InputParserClassName { get; set; }
    }
}
