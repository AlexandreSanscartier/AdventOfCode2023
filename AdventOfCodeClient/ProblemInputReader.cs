using AdventOfCodeClient.interfaces;
using System.Net;

namespace AdventOfCodeClient
{
    public class ProblemInputReader : IProblemInputReader
    {
        private string baseUri => "https://adventofcode.com";

        private IConfigurationService _configurationService;
        private IProblemInputCache _problemInputCache;

        public ProblemInputReader(IConfigurationService configurationService, IProblemInputCache problemInputCache)
        {
            this._configurationService = configurationService;
            _problemInputCache = problemInputCache;
        }

        public async Task<string> ReadInputFromUrlAsync(int problemNumber)
        {
            if(this._problemInputCache.IsCached(problemNumber)) {
                var cachedInputText = await this._problemInputCache.ReadFromCacheAsync(problemNumber);
                return cachedInputText.TrimEnd();
            }

            string inputText = string.Empty;
            var problemUri = this.generateInputUri(problemNumber);

            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (HttpClient httpClient = new HttpClient(handler) { BaseAddress = problemUri })
                {
                    // examples: https://adventofcode.com/2021/day/1/input
                    cookieContainer.Add(problemUri, new Cookie("session", this._configurationService.Session));
                    var result = await httpClient.GetAsync(problemUri);
                    result.EnsureSuccessStatusCode();

                    inputText = await result.Content.ReadAsStringAsync();
                    this._problemInputCache.WriteToCache(problemNumber, inputText);
                }
            }
            return inputText.TrimEnd();
        }

        private Uri generateInputUri(int problemNumber)
        {
            return new Uri(string.Format("{0}/{1}/day/{2}/input",
                    this.baseUri,
                    this._configurationService.Year,
                    problemNumber));
        }
    }
}
