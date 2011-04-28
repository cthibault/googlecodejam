using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class StoreCreditCases : Cases<StoreCreditProblem>
    {
        public override void Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<StoreCreditProblem>>();

            int number = 0;
            for (int i = 1; i < lines.Count(); i++)
            {
                cases.Add(new Case<StoreCreditProblem>(
                    ++number,
                    new StoreCreditProblem(int.Parse(lines[i]),
                                           lines[i += 2].Split(' ').ToList().ConvertAll(delegate(string n)
                                           {
                                               return int.Parse(n);
                                           }))
                    ));
            }

            CaseList = cases;
        }
    }
}
