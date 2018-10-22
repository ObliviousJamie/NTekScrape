using System.Collections.Generic;

namespace NTekScrape.Core.interfaces
{
    public interface ICharacterData
    {
        string Name { get; set; }
        IEnumerable<ICommand> Moves { get; set; }
    }
}