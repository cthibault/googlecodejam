using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace GoogleCodeJam.Common
{
    public static class GoogleCodeJamProblemHarness
    {
        private static Stopwatch Stopwatch = new Stopwatch();
        public static void LoadProblem<T>(Cases<T> cases, string filepath) where T:IProblem
        {
            Stopwatch.Restart();
            cases.Load(filepath);
            Stopwatch.Stop();

            Console.WriteLine("Assignment: {0} seconds", Stopwatch.Elapsed.TotalSeconds);
        }
        public static void Solve<T>(Cases<T> cases, string outputFilepath) where T:IProblem
        {
            Stopwatch.Restart();
            string results = cases.Solve().TrimEnd();
            Stopwatch.Stop();
            Console.WriteLine("Solve: {0} seconds", Stopwatch.Elapsed.TotalSeconds);

            OutputToFile(outputFilepath, results);
        }
        public static void OutputToFile(string filepath, string value)
        {
            Stopwatch.Restart();
            File.WriteAllText(filepath, value, Encoding.ASCII);
            Stopwatch.Stop();
            Console.WriteLine("Write To File: {0} seconds", Stopwatch.Elapsed.TotalSeconds);
        }
    }
}
