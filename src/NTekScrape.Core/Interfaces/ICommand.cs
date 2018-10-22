namespace NTekScrape.Core.Interfaces
{
    public interface ICommand
    {
        string Input { get; }
        string HitLevel { get; }
        string Damage { get; }
        string StartUp { get; }
        string BlockFrame { get; }
        string HitFrame { get; }
        string CounterHitFrame { get; }
        string Properties { get; }
    }
}
