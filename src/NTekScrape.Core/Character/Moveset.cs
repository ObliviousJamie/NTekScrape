using System.Collections.Generic;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Character
{
    public class Moveset : IMoveset
    {
        public string Name { get; set; }
        public IEnumerable<ICommand> Moves { get; set; }
    }
}
