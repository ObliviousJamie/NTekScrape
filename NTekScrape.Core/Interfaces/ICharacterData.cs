using System.Collections.Generic;

namespace NTekScrape.Core.interfaces
{
    public interface ICharacterData
    {
        string Name { get; }
        IEnumerable<ICommand> Moves();
    }
}