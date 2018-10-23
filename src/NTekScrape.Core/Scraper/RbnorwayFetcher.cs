using HtmlAgilityPack;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Scraper
{
    class RbnorwayFetcher : IHtmlWebWrapper
    {
        private readonly HtmlDocument _htmlDocument;

        public RbnorwayFetcher()
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
