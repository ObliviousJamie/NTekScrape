using HtmlAgilityPack;

namespace NTekScrape.Core.Interfaces
{
    public interface IHtmlWebWrapper
    {
        HtmlDocument GetHtmlDocument(string url);
    }
}
