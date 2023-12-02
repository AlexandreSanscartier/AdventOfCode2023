namespace AdventOfCodeClient.interfaces.services
{
    public interface ISolver
    {
        Task<string> SolvePartOneAsync();

        Task<string> SolvePartTwoAsync();
    }
}
