using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class AlienLanguageCases : Cases<AlienLanguageProblem>
    {
        public override void Load(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var cases = new List<Case<AlienLanguageProblem>>();

            string[] directions = lines[0].Split(' ');

            int dictionaryCount = int.Parse(directions[1]);
            List<string> dictionary = new List<string>();
            for (int i = 1; i <= dictionaryCount; i++)
                dictionary.Add(lines[i]);

            int number = 0;
            for (int i = ++dictionaryCount; i < lines.Count(); i++)
            {
                cases.Add(new Case<AlienLanguageProblem>(
                    ++number,
                    new AlienLanguageProblem(dictionary, lines[i])));
            }

            CaseList = cases;
        }
    }
}
