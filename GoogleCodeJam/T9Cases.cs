using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GoogleCodeJam
{
    public class T9Cases : Cases<T9Problem>
    {
        public T9Cases(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<T9Problem>>();

            int number = 0;
            for (int i = 1; i < lines.Count(); i++)
            {
                cases.Add(new Case<T9Problem>(
                    ++number,
                    new T9Problem(lines[i])));
            }

            CaseList = cases;
        }
    }
}
