using NTekScrape.Core.interfaces;

namespace NTekScrape.Core
{
    internal class Command : ICommand
    {
        public string Input { get; set; }

        public string HitLevel { get; set; }

        public string Damage { get; set; }

        public string StartUp { get; set; }

        public string BlockFrame { get; set; }

        public string HitFrame { get; set; }

        public string CounterHitFrame { get; set; }

        public string Properties { get; set; }
    }
}
