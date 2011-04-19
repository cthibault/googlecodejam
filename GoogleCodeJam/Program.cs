using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace GoogleCodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            string filePathPrefix = @"C:\Curtis\Applications\GoogleCodeJam\GoogleCodeJam\";

            stopwatch.Start();
            var a = new AlienLanguageCases(filePathPrefix + @"Input\2009 - Qualification Round\A-large-practice.in");
            stopwatch.Stop();
            var assignment = stopwatch.Elapsed;

            stopwatch.Reset();
            stopwatch.Start();
            File.WriteAllText(filePathPrefix + @"\Output\2009 - Qualification Round\A-large-practice.txt", a.Solve().TrimEnd(), Encoding.ASCII);
            stopwatch.Stop();

            var solve = stopwatch.Elapsed;

            //OUTPUT
            Console.WriteLine("Assignment: {0} seconds", assignment.TotalSeconds);
            Console.WriteLine("Solve: {0} seconds", solve.TotalSeconds);
            Console.Read();            
        }
    }
}
