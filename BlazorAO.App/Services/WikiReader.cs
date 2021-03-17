using BlazorAO.Models;
using Markdig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BlazorAO.Services
{
    public class WikiReader
    {
        private readonly string _wikiPath;
        private readonly Dictionary<int, Topic> _topics;
        private readonly IEnumerable<SourceFile> _sourceFiles;
        private readonly Dictionary<string, string> _rawSourceFiles;

        public WikiReader(IWebHostEnvironment environment, IOptions<WikiOptions> options)
        {
            _wikiPath = Path.Combine(environment.ContentRootPath, options.Value.LocalPath);

            _topics = Directory.EnumerateFiles(_wikiPath, "*.md", SearchOption.AllDirectories)
                .Select((fileName, index) => new Topic(fileName, index + 1))
                .ToDictionary(item => item.Id);

            _sourceFiles = Directory.EnumerateFiles(environment.ContentRootPath, "*", SearchOption.AllDirectories)
                .Where(fileName => !fileName.StartsWith(_wikiPath) && !IsBuildArtifact(fileName))
                .Select(fileName => new SourceFile()
                {
                    ViewUrl = options.Value.ViewLink + FormatFilename(fileName),
                    RawUrl = options.Value.RawLink + FormatFilename(fileName)
                }).ToArray();

            _rawSourceFiles = _sourceFiles.ToDictionary(file => file.ViewUrl, file => file.RawUrl);

            string FormatFilename(string fullPath) => fullPath.Substring(environment.ContentRootPath.Length).Replace("\\", "/");

            bool IsBuildArtifact(string fileName) => fileName.Contains("\\bin\\Release\\") || fileName.Contains("\\bin\\Debug\\") || fileName.Contains("\\obj\\");
        }

        public Dictionary<int, Topic> Topics { get => _topics; }

        public string Title { get; private set; }
        public HtmlString Content { get; private set; }

        public void LoadTopic(int id)
        {
            var topic = _topics[id];

            if (string.IsNullOrEmpty(topic.Html))
            {
                var markdown = File.ReadAllText(topic.Filename);
                var html = Markdown.ToHtml(markdown);

                html = InsertSourceLinks(html);

                topic.Html = html;
            }

            Title = topic.Title;
            Content = new HtmlString(topic.Html);
        }

        /// <summary>
        /// replaces links to source files with attributes that work with special js to fetch code into right pane
        /// </summary>
        private string InsertSourceLinks(string html)
        {
            var doc = XDocument.Parse($"<html>{html}</html>");

            var links = doc
                .Descendants()
                .Elements("a")    
                .Select(tag =>
                {
                    var linkInfo = IsSourceLink(tag);
                    return new
                    {
                        Tag = tag,
                        NewHref = (linkInfo.isSourceLink) ? "#" : linkInfo.newUrl,
                        IsInternal = linkInfo.isSourceLink,
                        RawCodeUrl = (linkInfo.isSourceLink) ? linkInfo.newUrl : string.Empty,
                        HighlightRange = !string.IsNullOrEmpty(linkInfo.lineNumber) ? linkInfo.lineNumber.Substring(1) : string.Empty
                    };
                }).ToArray();

            foreach (var link in links)
            {                
                if (link.IsInternal)
                {
                    var originalHref = link.Tag.Attribute(XName.Get("href")).Value;
                    link.Tag.Attribute(XName.Get("href")).Value = link.NewHref;

                    // source links will be invoked in a special way                    
                    link.Tag.Add(new XAttribute("data-codeview-url", link.RawCodeUrl));
                    link.Tag.Add(new XAttribute("data-highlight", link.HighlightRange));
                    link.Tag.Add(new XAttribute("data-external-url", originalHref));
                    link.Tag.Add(new XAttribute("class", "code-link"));                    
                }
                else
                {
                    // external (non-source) links will open in new window
                    link.Tag.Add(new XAttribute("target", "_blank"));
                    link.Tag.Add(new XAttribute("class", "new-window"));
                }
            }

            List<string> bodyNodes = new List<string>();
            bodyNodes.AddRange(doc.Root.Nodes().Select(node => node.ToString()));            
            return string.Join("\r\n", bodyNodes);

            (bool isSourceLink, string newUrl, string lineNumber) IsSourceLink(XElement tag)
            {
                var href = tag.Attribute(XName.Get("href")).Value;
                var parts = ParseLink(href);
                if (_rawSourceFiles.ContainsKey(parts.plainHref))
                {
                    return (true, _rawSourceFiles[parts.plainHref], parts.lineNumber);
                }
                else
                {
                    return (false, href, null);
                }
            }

            string GetLineNumber(string href)
            {
                var lineNumber = Regex.Match(href, @"#L.*");
                return (lineNumber.Success) ?
                    lineNumber.Value : 
                    string.Empty;
            }

            (bool hasLineNumber, string plainHref, string lineNumber) ParseLink(string href)
            {
                var lineNumber = GetLineNumber(href);
                if (!string.IsNullOrEmpty(lineNumber)) href = href.Replace(lineNumber, string.Empty);
                return ((!string.IsNullOrEmpty(lineNumber)), href, lineNumber);
            }
        }

        public class Topic
        {
            public Topic(string fileName, int index)
            {
                Filename = fileName;
                Title = ToTitle(fileName);
                Id = index;
            }

            public int Id { get; }
            public string Title { get; set; }
            public string Filename { get; set; }
            public string Html { get; set; }

            private static string ToTitle(string fileName)
            {
                string result = Path.GetFileNameWithoutExtension(fileName);
                return string.Join(" ", result.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries));                
            }
        }

        public class SourceFile
        {
            public string ViewUrl { get; set; }
            public string RawUrl { get; set; }
        }
    }
}
