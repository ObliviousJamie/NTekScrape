using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using NTekScrape.Core.Interfaces;
using NTekScrape.Core.Movelist;

namespace NTekScrape.Core.Scraper
{
    public class RbnorwayScraper : IScraper
    {
        private const string Prefix = @"http://rbnorway.org/";
        private const string Postfix = @"-t7-frames";

        private readonly IHtmlWebWrapper _htmlWeb;
        private readonly ICommandComparer _commandComparer;

        public RbnorwayScraper(IHtmlWebWrapper htmlWeb, ICommandComparer commandComparer)
        {
            _htmlWeb = htmlWeb;
            _commandComparer = commandComparer;
        }

        public IMoveset Download(string character)
        {
            var doc = _htmlWeb.GetHtmlDocument($"{Prefix}{character}{Postfix}");

            var specialMoves = AddMoves(doc.DocumentNode.SelectNodes("(//table)[1]"));
            var basicMoves = AddMoves(doc.DocumentNode.SelectNodes("(//table)[2]"));

            var allMoves = specialMoves.Union(basicMoves, _commandComparer);

            return new Moveset { Name = character, Moves = allMoves };
        }

        private IEnumerable<ICommand> AddMoves(HtmlNodeCollection table)
        {
            var commands = new List<ICommand>();

            // Return empty collection if there is no table
            if (table == null)
                return commands;

            foreach (var tr in table.Elements("tr"))
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

                if (!string.IsNullOrWhiteSpace(command.Input) && command.Input != "Command")
                    commands.Add(command);
            }

            return commands;
        }
    }
}