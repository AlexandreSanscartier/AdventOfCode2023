namespace AdventOfCodeClient.interfaces
{
    public interface IConfigurationService
    {
        string Year { get; }
        string Session { get; }
        bool UseProblemSender { get; }
    }
}
