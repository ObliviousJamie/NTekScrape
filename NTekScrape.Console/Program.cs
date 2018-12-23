using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

using NTekScrape.Core;

namespace NTekScrape.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Environment.CurrentDirectory;

            var fdr = new FrameDataRequester();
            var fighters = fdr.GetCharacters();

            var rejected = new List<string>();
            foreach (var fighter in fighters)
            {
                
                if (!fighter.Moves.Any())
                {
                    rejected.Add(fighter.Name);
                    continue;
                }

                var fighterJson = JsonConvert.SerializeObject(fighter, Formatting.Indented);
                Thread.Sleep(1000);
                var fileName = Path.Combine(currentDirectory, $"{fighter.Name}.json");
                File.WriteAllText(fileName, fighterJson);
                System.Console.WriteLine($"Written {fighter.Name}, with {fighter.Moves.Count()} moves");
            }
            rejected.ForEach(reject => System.Console.WriteLine($"Could not write {reject}"));
        }
    }
}
