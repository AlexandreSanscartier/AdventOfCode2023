namespace AdventOfCodeClient.interfaces
{
    public interface IProblemInputReader
    {
        /// <summary>
        /// Reads the problem input from the page and sends it as a string
        /// </summary>
        /// <param name="problemNumber">The problem number to get the problem input from</param>
        /// <returns>A string containing the problem input</returns>
        Task<string> ReadInputFromUrlAsync(int problemNumber);
    }
}
