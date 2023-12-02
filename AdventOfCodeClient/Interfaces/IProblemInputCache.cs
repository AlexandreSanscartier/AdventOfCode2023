namespace AdventOfCodeClient.interfaces
{
    /// <summary>
    /// Defines a caching system for the problem input
    /// </summary>
    public interface IProblemInputCache
    {
        /// <summary>
        /// Checks if the problem input is cached.
        /// </summary>
        /// <param name="problemNumber">The problem number to check the cache for.</param>
        /// <returns>Whether the problem input is cached or not.</returns>
        bool IsCached(int problemNumber);

        /// <summary>
        /// Writes the input to cache.
        /// </summary>
        /// <param name="problemNumber">The problem number to write the cache for.</param>
        /// <param name="input">The input to write to cache.</param>
        void WriteToCache(int problemNumber, string input);

        /// <summary>
        /// Writes the input to cache.
        /// </summary>
        /// <param name="problemNumber">The problem number to write the cache for.</param>
        /// <param name="input">The input to write to cache.</param>
        void WriteToCache(int problemNumber, string[] input);

        /// <summary>
        /// Reads the input from cache.
        /// </summary>
        /// <param name="problemNumber">The problem number to read the cache for.</param>
        /// <returns>The cache's input.</returns>
        Task<string> ReadFromCacheAsync(int problemNumber);
    }
}
