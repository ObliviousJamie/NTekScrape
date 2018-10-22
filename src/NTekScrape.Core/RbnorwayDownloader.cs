using NTekScrape.Core.interfaces;
using NTekScrape.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NTekScrape.Core
{
    public class RbnorwayDownloader : ICharacterDownloader
    {
        private const string PREFIX = @"http://rbnorway.org/";
        private const string POSTFIX = @"-t7-frames";

        private IHtmlWebWrapper _htmlWeb;

        public RbnorwayDownloader(IHtmlWebWrapper htmlWeb)
        {
            _htmlWeb = htmlWeb;
        }

        //TODO add basic and/or special option
        public ICharacterData Download(string character)
        {
            var doc = _htmlWeb.GetHtmlDocument($"{PREFIX}/{character}{POSTFIX}");

            // Select all special moves
            var specialMovesTrElement = doc.DocumentNode.SelectNodes("(//tbody)[1]");

            var commands = new List<ICommand>();
            foreach(var tr in specialMovesTrElement.Elements("tr"))
            {
                var moveProperties = tr.Elements("td").ToList();

                var command = new Command
                {
                    Input = moveProperties[0].InnerText,
                    HitLevel = moveProperties[1].InnerText,
                    Damage = moveProperties[2].InnerText,
                    StartUp = moveProperties[3].InnerText,
                    BlockFrame = moveProperties[4].InnerText,
                    HitFrame = moveProperties[5].InnerText,
                    CounterHitFrame = moveProperties[6].InnerText,
                    Properties = moveProperties[7].InnerText,
                };

                if(!string.IsNullOrWhiteSpace(command.Input) && command.Input != "Command")
                    commands.Add(command);
            }

            return new CharacterData { Name = character, Moves = commands };
        }
    }
}