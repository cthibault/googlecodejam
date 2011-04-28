using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam.Common
{
    public class Case<T> where T : IProblem
    {
        public int Number { get; set; }
        public T Problem { get; set; }

        public Case(int number, T problem)
        {
            Number = number;
            Problem = problem;
        }

        public string Solve()
        {
            return string.Format("Case #{0}: {1}", Number, Problem.Solve());
        }
    }
}
