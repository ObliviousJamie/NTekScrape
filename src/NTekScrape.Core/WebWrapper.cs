using NTekScrape.Core.Interfaces;
using HtmlAgilityPack;

namespace NTekScrape.Core
{
    class WebWrapper : IHtmlWebWrapper
    {
        private HtmlDocument _htmlDocument;

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
