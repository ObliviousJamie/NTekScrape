namespace NTekScrape.Core
{
    public interface ICharacterData
    {
        string Name { get; }
        IEnumerable<ICommand> Moves();
    }
}