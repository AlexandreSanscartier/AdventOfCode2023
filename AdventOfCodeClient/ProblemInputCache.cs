using AdventOfCodeClient.interfaces;

namespace AdventOfCodeClient
{
    public class ProblemInputCache : IProblemInputCache
    {
        private readonly IConfigurationService _configurationService;
        private readonly string _inputFolder = Path.Combine(Environment.CurrentDirectory, "inputs");

        public ProblemInputCache(IConfigurationService configurationService)
        {
            this._configurationService = configurationService;
        }

        public bool IsCached(int problemNumber)
        {
            var filePath = this.GenerateProblemInputPath(problemNumber);
            return File.Exists(filePath);
        }

        public async Task<string> ReadFromCacheAsync(int problemNumber)
        {
            var filePath = this.GenerateProblemInputPath(problemNumber);
            return await File.ReadAllTextAsync(filePath);
        }

        public void WriteToCache(int problemNumber, string input)
        {
            var filePath = this.GenerateProblemInputPath(problemNumber);
            Directory.CreateDirectory(_inputFolder);
            File.WriteAllText(filePath, input);
        }

        public void WriteToCache(int problemNumber, string[] input)
        {
            var filePath = this.GenerateProblemInputPath(problemNumber);
            Directory.CreateDirectory(_inputFolder);
            File.WriteAllLines(filePath, input);
        }

        private string GenerateProblemInputPath(int problemNumber)
        {
            var filePath = Path.Combine(_inputFolder, $"InputDay{problemNumber}.txt");
            return filePath;
        }
    }
}
