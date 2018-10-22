using NTekScrape.Core.interfaces;
using NTekScrape.Core.Interfaces;
using SimpleInjector;

namespace NTekScrape.Core
{
    public class IocContainer
    {
        public readonly Container container;

        public IocContainer(FrameDataSource dataSource)
        {
            container = new Container();
            RegisterAll(dataSource);
        }

        private void RegisterAll(FrameDataSource dataSource)
        {
            container.Register<IScraper, RbnorwayScraper>();
            container.Register<IHtmlWebWrapper, WebWrapper>();
            container.Verify();
        }
    }
}
