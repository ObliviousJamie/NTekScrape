using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Helpers
{
    public class CommandComparer : ICommandComparer
    {
        public bool Equals(ICommand c1, ICommand c2)
        {
            if (c1 == null || c2 == null)
                return false;

            return c1.Input == c2.Input;
        }

        public int GetHashCode(ICommand c)
        {
            return c.Input.GetHashCode();
        }
    }
}
