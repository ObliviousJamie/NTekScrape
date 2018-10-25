using System;
using System.Collections.Generic;
using System.Linq;
using NTekScrape.Core.Interfaces;
using NTekScrape.Core.Ioc;

namespace NTekScrape.Core
{
    public class FrameDataRequester
    {
        private readonly IScraper _downloader;
        private readonly IParser _parser;

        public FrameDataRequester(FrameDataSource dataSource = FrameDataSource.Default, IScraper scraper = null)
        {
            var container = new IocContainer(dataSource).Container;
            _downloader =  scraper ?? container.GetInstance<IScraper>();
            _parser = container.GetInstance<IParser>();
        }

        public IEnumerable<IMoveset> GetCharacters()
        {
            var staticCharacters = (Character[]) Enum.GetValues(typeof(Character));

            foreach (var character in staticCharacters)
            {
                var stringCharacter = _parser.Parse(character);
                yield return GetCharacter(stringCharacter);
            }
        }

        public IMoveset GetCharacter(Character character)
        {
            var stringCharacter = _parser.Parse(character);
            return _downloader.Download(stringCharacter);
        }

        public IMoveset GetCharacter(string character)
        {
            character = character.ToLower();
            return _downloader.Download(character);
        }
    }
}
