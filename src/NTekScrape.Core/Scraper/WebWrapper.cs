using HtmlAgilityPack;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Scraper
{
    internal class WebWrapper : IHtmlWebWrapper
    {
        private readonly HtmlDocument _htmlDocument;

        public WebWrapper()
        {
            _htmlDocument = new HtmlDocument();
        }

        public HtmlDocument GetHtmlDocument(string url)
        {
            _htmlDocument.LoadHtml(url);
            return _htmlDocument;
        }
    }
}
