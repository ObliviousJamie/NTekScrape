using NTekScrape.Core.interfaces;
using System.Collections.Generic;

namespace NTekScrape.Core
{
    public class Moveset : IMoveset
    {
        public string Name { get; set; }
        public IEnumerable<ICommand> Moves { get; set; }
    }
}
