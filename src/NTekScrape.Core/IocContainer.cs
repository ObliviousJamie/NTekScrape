using NTekScrape.Core.interfaces;
using NTekScrape.Core.Interfaces;
using SimpleInjector;

namespace NTekScrape.Core
{
    public class IocContainer
    {
        public readonly Container container;

        public IocContainer(FrameSource source)
        {
            container = new Container();
            RegisterAll(source);
        }

        private void RegisterAll(FrameSource source)
        {
            container.Register<ICharacterDownloader, RbnorwayDownloader>();
            container.Register<IHtmlWebWrapper, RbnorwayFetcher>();
            container.Verify();
        }
    }
}
