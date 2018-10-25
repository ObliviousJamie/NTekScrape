using HtmlAgilityPack;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Scraper
{
    internal class WebWrapper : IHtmlWebWrapper
    {
        private readonly HtmlWeb _htmlWeb;

        public WebWrapper()
        {
            _htmlWeb = new HtmlWeb();
        }

        public HtmlDocument GetHtmlDocument(string url)
        {
            return _htmlWeb.Load(url);
        }
    }
}
