using System;
using System.Collections.Generic;
using System.Linq;

namespace NTekScrape.Core
{
    public class CharacterExtractor
    {
        private readonly FrameSource _source;
        private ICharacterDownloader _downloader;

        public CharacterExtractor(FrameSource source = FrameSource.Default)
        {
            _source = source;
            if (_source == FrameSource.Default)
                _source = FrameSource.Rbnorway;

            _downloader = new DownloadFactory().CreateDownloader(source);
        }

        public IEnumerable<ICharacterData> GetCharacters(IEnumerable<string> characters = null)
        {
            var staticCharacters = Enum.GetValues(typeof(Character)).Cast<string>();
            characters = characters ?? staticCharacters;

            foreach (var character in characters)
            {
                yield return GetCharacter(character);
            }
        }

        public ICharacterData GetCharacter(Character character)
        {
            return _downloader.Download(character.ToString().ToLower());
        }

        private ICharacterData GetCharacter(string character)
        {
            character = character.ToLower();
            return _downloader.Download(character);
        }
    }
}
