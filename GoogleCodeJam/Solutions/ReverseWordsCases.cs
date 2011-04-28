using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class ReverseWordsCases : Cases<ReverseWordsProblem>
    {
        public override void Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<ReverseWordsProblem>>();

            int number = 0;
            for (int i = 1; i < lines.Count(); i++)
            {
                cases.Add(new Case<ReverseWordsProblem>(
                    ++number,
                    new ReverseWordsProblem(lines[i])));
            }

            CaseList = cases;
        }
    }
}
