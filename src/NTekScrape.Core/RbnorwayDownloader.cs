using HtmlAgilityPack;
using NTekScrape.Core.interfaces;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core
{
    public class RbnorwayDownloader : ICharacterDownloader
    {
        private IHtmlWebWrapper _htmlWeb;

        public RbnorwayDownloader(IHtmlWebWrapper htmlWeb)
        {
            _htmlWeb = htmlWeb;
        }

        public ICharacterData Download(string character)
        {
            _htmlWeb.GetHtmlDocument();
        }
    }
}