using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.interfaces.services;
using AdventOfCodeClient.Interfaces.Parsers;

namespace AdventOfCodeClient.Solvers
{
    public abstract class BaseSolver<T> : ISolver
    {
        private readonly IProblemInputReader _problemInputReader;
        private readonly IProblemOutputSender _problemOutputSender;
        private readonly IInputParser<T> _inputParser;

        protected BaseSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IInputParser<T> inputParser)
        {
            this._problemInputReader = problemInputReader;
            this._problemOutputSender = problemOutputSender;
            this._inputParser = inputParser;
        }

        /// <summary>
        /// Gets the day that this solver is made for
        /// </summary>
        public abstract int Day { get; }

        /// <summary>
        /// The solver for adventofcode part one
        /// </summary>
        /// <param name="input">The parsed input</param>
        /// <returns>the anwser to part one</returns>
        public abstract string SolvePartOne(T input);

        /// <summary>
        /// The solver for adventofcode part two
        /// </summary>
        /// <param name="input">The parsed input</param>
        /// <returns>the anwser to part two</returns>
        public abstract string SolvePartTwo(T input);

        public async Task<string> SolvePartOneAsync()
        {
            // Read the problem input
            var input = await this._problemInputReader.ReadInputFromUrlAsync(this.Day);
           var parsedInput = this._inputParser.ParseProblemOneInput(input);

            // Perform operations to get the answer
            var result = this.SolvePartOne(parsedInput);
            await this._problemOutputSender.SendAsync(Day, 1, result);
            return result;
        }

        public async Task<string> SolvePartTwoAsync()
        {
            var input = await this._problemInputReader.ReadInputFromUrlAsync(this.Day);
            var parsedInput = this._inputParser.ParseProblemTwoInput(input);

            // Perform operations to get the answer
            var result = this.SolvePartTwo(parsedInput);
            await this._problemOutputSender.SendAsync(Day, 2, result);
            return result;
        }
    }
}
