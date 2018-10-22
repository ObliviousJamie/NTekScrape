using System.Collections.Generic;

namespace NTekScrape.Core.interfaces
{
    public interface IMoveset
    {
        string Name { get; set; }
        IEnumerable<ICommand> Moves { get; set; }
    }
}