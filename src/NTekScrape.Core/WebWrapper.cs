using NTekScrape.Core.Interfaces;
using HtmlAgilityPack;

namespace NTekScrape.Core
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
