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

            string sInputPrefix = @"Input\2009 - Qualification Round\B-small-practice.in";
            string lInputPrefix = @"Input\2009 - Qualification Round\B-large-practice.in";
            string sOutputPrefix = @"\Output\2009 - Qualification Round\B-small-practice.txt";
            string lOutputPrefix = @"\Output\2009 - Qualification Round\B-large-practice.txt";

            sInputPrefix = @"\Input\test.in";
            sOutputPrefix = @"\Output\test.txt";

            string inputPrefix = sInputPrefix;
            string outputPrefix = sOutputPrefix;

            Console.Write("Run the small input (y/n): ");
            string input = Console.ReadLine();
            if ((input != "Y") && (input != "y"))
            {
                inputPrefix = lInputPrefix;
                outputPrefix = lOutputPrefix;
            }

            stopwatch.Start();
            var cases = new WatershedsCases(filePathPrefix + inputPrefix);
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
