using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    public class AlienLanguageProblem : IProblem
    {
        public IEnumerable<string> Dictionary { get; set; }
        public string Word { get; set; }

        public AlienLanguageProblem(IEnumerable<string> dictionary, string word)
        {
            Dictionary = dictionary;
            Word = word;
        }

        public string Solve()
        {
            IEnumerable<string> wordDefinition = AlienLanguageProblem.Parse(Word);
            List<string> results = new List<string>();
            _combinations(ref results, string.Empty, wordDefinition);

            var count = results.Count(r => Dictionary.Contains(r));
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
        private void _combinations(ref List<string> results, string output, IEnumerable<string> definition)
        {
            if (definition.Count() == 0)
            {
                results.Add(output);
            }
            else
            {
                foreach (char c in definition.First())
                {
                    if (Dictionary.Any(w => w.StartsWith(output + c)))
                        _combinations(ref results, output + c, definition.Skip(1));
                }
            }
        }
    }
}
