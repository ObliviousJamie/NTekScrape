using NTekScrape.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace NTekScrape.Core
{
    class RbnorwayFetcher : IHtmlWebWrapper
    {
        private HtmlDocument _htmlDocument;

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
