using System;
using System.Collections.Generic;
using System.Linq;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core
{
    public class FrameDataRequester
    {
        private readonly IScraper _downloader;

        public FrameDataRequester(FrameDataSource dataSource = FrameDataSource.Default)
        {
            var container = new IocContainer(dataSource).Container;
            _downloader = container.GetInstance<IScraper>();
        }

        public IEnumerable<IMoveset> GetCharacters(IEnumerable<string> characters = null)
        {
            var staticCharacters = Enum.GetValues(typeof(Character)).Cast<string>();
            characters = characters ?? staticCharacters;

            foreach (var character in characters)
            {
                yield return GetCharacter(character);
            }
        }

        public IMoveset GetCharacter(Character character)
        {
            return _downloader.Download(character.ToString().ToLower());
        }

        private IMoveset GetCharacter(string character)
        {
            character = character.ToLower();
            return _downloader.Download(character);
        }
    }
}
