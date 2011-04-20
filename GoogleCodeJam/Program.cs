using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace GoogleCodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            string filePathPrefix = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePathPrefix = filePathPrefix.Remove(filePathPrefix.IndexOf("bin"));

            string sInputPrefix = @"Input\2009 - Qualification Round\A-small-practice.in";
            string lInputPrefix = @"Input\2009 - Qualification Round\A-large-practice.in";
            string sOutputPrefix = @"\Output\2009 - Qualification Round\A-small-practice.txt";
            string lOutputPrefix = @"\Output\2009 - Qualification Round\A-large-practice.txt";
            
            bool useSmall = false;
            string inputPrefix = sInputPrefix;
            string outputPrefix = sOutputPrefix;

            if (!useSmall)
            {
                inputPrefix = lInputPrefix;
                outputPrefix = lOutputPrefix;
            }

            stopwatch.Start();
            var cases = new AlienLanguageCases(filePathPrefix + inputPrefix);
            stopwatch.Stop();
            Console.WriteLine("Assignment: {0} seconds", stopwatch.Elapsed.TotalSeconds);

            stopwatch.Reset();
            stopwatch.Start();
            File.WriteAllText(filePathPrefix + outputPrefix, cases.Solve().TrimEnd(), Encoding.ASCII);
            stopwatch.Stop();
            Console.WriteLine("Solve: {0} seconds", stopwatch.Elapsed.TotalSeconds);
            
            
            Console.Read();            
        }
    }
}
