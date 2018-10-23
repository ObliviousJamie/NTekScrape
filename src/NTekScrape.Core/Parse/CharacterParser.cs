﻿using System.Text;
using NTekScrape.Core.Interfaces;

namespace NTekScrape.Core.Parse
{
    internal class CharacterParser : IParser
    {
        public string Parse(Character character)
        {
            switch (character)
            {
                case Character.DevilJin:
                    return SplitCharacterName(character);
                case Character.LuckyChole:
                    return SplitCharacterName(character);
                case Character.MasterRaven:
                    return SplitCharacterName(character);
                default:
                    return character.ToString().ToLower();
            }
        }

        private string SplitCharacterName(Character character)
        {
            var camalCaseCharacter = character.ToString();
            var builder = new StringBuilder();
            foreach (var letter in camalCaseCharacter)
            {
                if (char.IsUpper(letter) && builder.Length > 0)
                    builder.Append("-");

                builder.Append(char.ToLower(letter));
            }

            return builder.ToString();
        }
    }
}
