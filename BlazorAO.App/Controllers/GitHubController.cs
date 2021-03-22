using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BlazorAO.Controllers
{
    public class GitHubController : Controller
    {
        private static HttpClient _client = new HttpClient();

        /// <summary>
        /// meant for getting a "raw" code URL from github, inserts line numbers and highlights any selected line(s) from #L hash
        /// </summary>
        public async Task<ContentResult> Source(string url, string highlight)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content = HttpUtility.HtmlEncode(content);
            var lines = content.Split(new char[] { '\r', '\n' });
            var highlightRange = ParseHighlightRange(highlight);
            var numberedLines = lines.Select((line, index) =>
            {
                var isHighlight = (highlightRange.min > -1 && highlightRange.max > -1) && (index + 1) >= highlightRange.min && (index + 1) <= highlightRange.min;
                var highlightClass = (isHighlight) ? "highlight" : string.Empty;
                return $"<span class=\"line-number\">{index + 1}:</span><span class=\"{highlightClass}\">{line}</span>";
            });

            return Content(string.Join("\r\n", numberedLines), "text/html");
        }

        /// <summary>
        /// for example
        /// https://raw.githubusercontent.com/adamfoneil/BlazorStarter/master/BlazorStarter/Startup.cs#L53-L55
        /// would return (53, 55)
        /// </summary>
        private (int min, int max) ParseHighlightRange(string range)
        {
            if (string.IsNullOrEmpty(range)) return (-1, -1);

            var lineRange = range.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (lineRange.Length == 1) return (int.Parse(lineRange[0].Substring(1)), int.Parse(lineRange[0].Substring(1)));
            if (lineRange.Length == 2) return (int.Parse(lineRange[0].Substring(1)), int.Parse(lineRange[1].Substring(1)));

            throw new InvalidOperationException($"Unexpected line range request: {range}");
        }
    }
}
