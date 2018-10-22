using NTekScrape.Core.Interfaces;
using HtmlAgilityPack;

namespace NTekScrape.Core
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
