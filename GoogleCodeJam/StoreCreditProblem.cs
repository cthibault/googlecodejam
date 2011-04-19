using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    public class StoreCreditProblem : IProblem
    {
        public int StoreCredit { get; set; }
        public List<int> Items { get; set; }

        public StoreCreditProblem(int storeCredit, IEnumerable<int> items)
        {
            StoreCredit = storeCredit;
            Items = items.ToList();
        }

        public string Solve()
        {
            for (int i = 0; i < Items.Count(); i++)
                for (int j = i + 1; j < Items.Count(); j++)
                    if (Items[i] + Items[j] == StoreCredit)
                        return string.Format("{0} {1}", i+1, j+1);
            return string.Empty;
        }
    }
}
