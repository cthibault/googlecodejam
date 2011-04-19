using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    public abstract class Cases<T> where T:IProblem
    {
        public IEnumerable<Case<T>> CaseList { get; set; }

        public virtual string Solve()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var c in CaseList)
                builder.AppendLine(c.Solve());
            return builder.ToString();
        }
    }
}
