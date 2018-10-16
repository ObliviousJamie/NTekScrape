namespace NTekScrape.Core.interfaces
{
    public interface ICommand
    {
        string Input { get; }
        string Damage { get; }
        string StartUp { get; }
        string BlockFrame { get; }
        string HitFrame { get; }
        string CounterHitFrame { get; }
        string Properties { get; }
    }
}
