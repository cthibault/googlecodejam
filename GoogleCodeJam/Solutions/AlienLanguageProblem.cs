using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class AlienLanguageProblem : IProblem
    {
        public IEnumerable<string> Dictionary { get; set; }
        public string Word { get; set; }
        public Func<string, bool> Filter { get; set; }

        public string LogFile { get; set; }

        public AlienLanguageProblem(IEnumerable<string> dictionary, string word)
        {
            Dictionary = dictionary;
            Word = word;

            LogFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogFile = string.Format("{0}Output\\logfile.log", LogFile.Remove(LogFile.IndexOf("bin")));
            File.WriteAllText(LogFile, string.Empty);
        }

        public string Solve()
        {
            string[] wordDefinition = AlienLanguageProblem.Parse(Word).ToArray();
            File.AppendAllText(LogFile, string.Format("{0}{1}", Word, Environment.NewLine));

            var count = _checkAgainstDefinition(wordDefinition);
            return count.ToString();
        }

        public static IEnumerable<string> Parse(string input)
        {
            List<string> sets = new List<string>();
            string output = string.Empty;
            bool buildSet = false;

            foreach (char c in input)
            {
                switch (c)
                {
                    case '(':
                        buildSet = true;
                        break;
                    case ')':
                        buildSet = false;
                        break;

                    default:
                        output += c;
                        break;
                }

                if (!buildSet)
                {
                    sets.Add(output);
                    output = string.Empty;
                }
            }

            return sets;
        }

        private int _checkAgainstDefinition(string[] definition)
        {
            int count = 0;
            foreach (string word in Dictionary)
                if (_checkAgainstDefinition(word, definition))
                    count++;
            return count;
        }
        private bool _checkAgainstDefinition(string word, string[] definition)
        {
            for (int i = 0; i < word.Length; i++)
                if (!definition[i].Contains(word[i]))
                    return false;
            return true;
        }

        //Too slow
        private void _combinations(ref List<string> results, string output, IEnumerable<string> definition, IEnumerable<string> dictionary)
        {
            if (definition.Count() == 0)
            {
                results.Add(output);
            }
            else
            {
                string temp;
                IEnumerable<string> newDictionary;
                foreach (char c in definition.First())
                {
                    temp = output + c;
                    newDictionary = dictionary.Where(w => w.StartsWith(temp));

                    File.AppendAllText(LogFile, string.Format(" {0}  {1}{2}",
                        newDictionary.Count().ToString().PadLeft(4), temp, Environment.NewLine));

                    if (newDictionary.Count() > 0)
                        _combinations(ref results, temp, definition.Skip(1), newDictionary);

                }
            }
        }
    }
}
