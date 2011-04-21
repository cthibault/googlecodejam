using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    public class WatershedsProblem : IProblem
    {
        public List<List<int>> Grid { get; set; }
        public WatershedsProblem(List<List<int>> grid)
        {
            Grid = grid;
        }

        public string Solve()
        {
            return "";
        }
    }
}
