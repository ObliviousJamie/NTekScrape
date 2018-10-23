using System;
using System.Collections.Generic;
using System.Linq;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core
{
    public class FrameDataRequester
    {
        private readonly IScraper _downloader;
        private readonly IParser _parser;

        public FrameDataRequester(FrameDataSource dataSource = FrameDataSource.Default)
        {
            var container = new IocContainer(dataSource).Container;
            _downloader = container.GetInstance<IScraper>();
            _parser = container.GetInstance<IParser>();
        }

        public IEnumerable<IMoveset> GetCharacters(IEnumerable<string> characters = null)
        {
            var staticCharacters = Enum.GetValues(typeof(Character.Character)).Cast<string>();
            characters = characters ?? staticCharacters;

            foreach (var character in characters)
            {
                yield return GetCharacter(character);
            }
        }

        public IMoveset GetCharacter(Character.Character character)
        {
            var stringCharacter = _parser.Parse(character);
            return _downloader.Download(stringCharacter);
        }

        private IMoveset GetCharacter(string character)
        {
            character = character.ToLower();
            return _downloader.Download(character);
        }
    }
}
