using NTekScrape.Core.Helpers;
using NTekScrape.Core.Interfaces;
using NTekScrape.Core.Parse;
using NTekScrape.Core.Scraper;
using SimpleInjector;

namespace NTekScrape.Core.Ioc
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
            Container.Register<IParser, CharacterParser>();
            Container.Register<ICommandComparer, CommandComparer>();
            Container.Verify();
        }
    }
}