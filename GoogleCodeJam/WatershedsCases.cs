using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GoogleCodeJam
{
    public class WatershedsCases : Cases<WatershedsProblem>
    {
        public WatershedsCases(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<WatershedsProblem>>();

            int number = 0;
            List<int> gridDef;
            List<List<int>> grid;
            for (int i = 1; i < lines.Count(); i++)
            {
                gridDef = lines[i].Split(' ').ToList().ConvertAll(delegate(string n) { return int.Parse(n); });
                
                grid = new List<List<int>>();
                for (int j = i + 1; j <= gridDef[0]+i; j++)
                    grid.Add(lines[j].Split(' ').ToList().ConvertAll(delegate(string n) { return int.Parse(n); }));

                cases.Add(new Case<WatershedsProblem>(
                    ++number,
                    new WatershedsProblem(grid)));
                i += gridDef[0];
            }

            CaseList = cases;
        }
    }
}
