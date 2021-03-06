﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GoogleCodeJam.Common;

namespace GoogleCodeJam.Solutions
{
    public class T9Cases : Cases<T9Problem>
    {
        public override void Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<T9Problem>>();

            int number = 0;
            for (int i = 1; i < lines.Count(); i++)
            {
                cases.Add(new Case<T9Problem>(
                    ++number,
                    new T9Problem(lines[i])));
            }

            CaseList = cases;
        }
    }
}
