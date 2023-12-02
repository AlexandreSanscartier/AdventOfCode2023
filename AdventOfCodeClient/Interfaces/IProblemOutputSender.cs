namespace AdventOfCodeClient.interfaces
{
    public interface IProblemOutputSender
    {
        /// <summary>
        /// Posts the problem's answer to Advent of Code.
        /// </summary>
        /// <param name="anwser">The answer to send.</param>
        /// <returns>Whether the answer was correct or not.</returns>
        public Task<bool> SendAsync(int day, int level, string answer);
    }
}
