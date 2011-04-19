using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GoogleCodeJam
{
    public class StoreCreditCases : Cases<StoreCreditProblem>
    {
        public StoreCreditCases(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<StoreCreditProblem>>();

            int number = 0;
            for (int i = 1; i < lines.Count(); i++)
            {
                cases.Add(new Case<StoreCreditProblem>(
                    ++number,
                    new StoreCreditProblem(int.Parse(lines[i]), 
                                           lines[i+=2].Split(' ').ToList().ConvertAll(delegate(string n)
                                           {
                                               return int.Parse(n);
                                           }))
                    ));
            }

            CaseList = cases;
        }
    }
}
