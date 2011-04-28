using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam.Common
{
    public abstract class Cases<T> where T:IProblem
    {
        public IEnumerable<Case<T>> CaseList { get; set; }

        public virtual string Solve()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var c in CaseList)
            {
                Console.Write("  Solving Case #{0}:  ", c.Number.ToString().PadRight(2));
                builder.AppendLine(c.Solve());
                Console.WriteLine("Finished");
            }
            return builder.ToString();
        }
        public abstract void Load(string filepath);
    }
}
