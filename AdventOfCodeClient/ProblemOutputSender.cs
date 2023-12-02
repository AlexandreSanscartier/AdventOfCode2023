using AdventOfCodeClient.interfaces;
using System.Net;

namespace AdventOfCodeClient
{
    public class ProblemOutputSender : IProblemOutputSender
    {
        private string baseUri => "https://adventofcode.com";

        private IConfigurationService _configurationService;

        public ProblemOutputSender(IConfigurationService configurationService)
        {
            this._configurationService = configurationService;
        }

        public async Task<bool> SendAsync(int day, int level, string answer)
        {
            if (this._configurationService.UseProblemSender)
            {
                var answerUri = this.generateInputUri(day);
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                {
                    using (var httpClient = new HttpClient() { BaseAddress = answerUri })
                    {
                        cookieContainer.Add(answerUri, new Cookie("session", this._configurationService.Session));
                        List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                        postData.Add(new KeyValuePair<string, string>("level", level.ToString()));
                        postData.Add(new KeyValuePair<string, string>("answer", answer));

                        using (var content = new FormUrlEncodedContent(postData))
                        {
                            content.Headers.Clear();
                            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                            HttpResponseMessage response = await httpClient.PostAsync(answerUri, content);

                            var responseMessage = await response.Content.ReadAsStringAsync();
                            if (responseMessage.Contains("That's the right answer!", StringComparison.InvariantCultureIgnoreCase))
                            {
                                // Right! Anwser
                                return true;
                            }
                            else
                            {
                                // Wrong Answer
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private Uri generateInputUri(int day)
        {
            return new Uri(string.Format("{0}/{1}/day/{2}/answer",
                    this.baseUri,
                    this._configurationService.Year,
                    day));
        }
    }
}
