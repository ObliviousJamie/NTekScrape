namespace NTekScrape.Core
{
    public interface ICharacterDownloader
    {
        ICharacterData Download(string character);
    }
}
