using NTekScrape.Core.Interfaces;
using SimpleInjector;

namespace NTekScrape.Core
{
    internal class IocContainer
    {
        public readonly Container Container;

        public IocContainer(FrameDataSource dataSource)
        {
            Container = new Container();
            RegisterAll();
        }

        private void RegisterAll()
        {
            Container.Register<IScraper, RbnorwayScraper>();
            Container.Register<IHtmlWebWrapper, WebWrapper>();
            Container.Verify();
        }
    }
}