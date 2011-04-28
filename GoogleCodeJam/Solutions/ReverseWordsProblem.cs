using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class ReverseWordsProblem : IProblem
    {
        public string Words { get; set; }
        
        public ReverseWordsProblem(string words)
        {
            Words = words;
        }

        public string Solve()
        {
            var reverseList = Words.Split(' ').Reverse();
            StringBuilder builder = new StringBuilder();
            foreach (string word in reverseList)
                builder.Append(word + " ");

            return builder.ToString().TrimEnd();
        }
    }
}
