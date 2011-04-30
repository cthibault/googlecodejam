using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
//Specific References


namespace GoogleCodeJam.QuickSolutions.Rotate
{
    #region Specific Classes
    public class Rotate
    {
        public static void Run()
        {
            string filePathPrefix = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePathPrefix = filePathPrefix.Remove(filePathPrefix.IndexOf("bin"));

            string inputPrefix = @"Input\test.in";
            string outputPrefix = @"\Output\test.txt";

            var cases = new RotateCases();
            GoogleCodeJamProblemHarness.LoadProblem<RotateProblem>(cases, filePathPrefix + inputPrefix);
            GoogleCodeJamProblemHarness.Solve<RotateProblem>(cases, filePathPrefix + outputPrefix);
        }
    }

    public class RotateCases : Cases<RotateProblem>
    {
        public override void Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            var cases = new List<Case<RotateProblem>>();

            int number = 0;
            List<int> definitions;
            List<string> grid;
            for (int i = 1; i < lines.Count(); i++)
            {
                definitions = lines[i].Split(' ').ToList().ConvertAll(delegate(string n) { return int.Parse(n); });

                grid = new List<string>();
                for (int j = i + 1; j <= definitions[0] + i; j++)
                    grid.Add(lines[j]);

                cases.Add(new Case<RotateProblem>(
                    ++number,
                    new RotateProblem(grid, definitions[1])));
                i += definitions[0];
            }

            CaseList = cases;
        }
    }

    public class RotateProblem : IProblem
    {
        public List<string> Grid { get; set; }
        public int ConsecutivePieces { get; set; }

        public RotateProblem(List<string> grid, int consecutivePieces)
        {
            Grid = grid;
            ConsecutivePieces = consecutivePieces;
        }

        public string Solve()
        {
            //PrettyPrintGrid();
            _rotateClockwise();
            return string.Empty;
        }
        public void PrettyPrintGrid()
        {
            Console.WriteLine();
            Grid.ForEach(line => Console.WriteLine(line));
        }

        private void _rotateClockwise()
        {
            List<string> newGrid = new List<string>();
            int length = Grid.First().Length;
            for (int i = 0; i < length; i++)
                newGrid.Add(string.Concat(Grid.Select(l => l[i]).Reverse()));

            PrettyPrintGrid();
            Console.WriteLine();
            Grid = newGrid;
            PrettyPrintGrid();
        }
    }
    #endregion Specific Classes

    #region Common Classes and Interfaces
    public interface IProblem
    {
        string Solve();
    }

    public abstract class Cases<T> where T : IProblem
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

    public static class GoogleCodeJamProblemHarness
    {
        private static Stopwatch Stopwatch = new Stopwatch();
        public static void LoadProblem<T>(Cases<T> cases, string filepath) where T : IProblem
        {
            Stopwatch.Restart();
            cases.Load(filepath);
            Stopwatch.Stop();

            Console.WriteLine("Assignment: {0} seconds", Stopwatch.Elapsed.TotalSeconds);
        }
        public static void Solve<T>(Cases<T> cases, string outputFilepath) where T : IProblem
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
    #endregion Common Classes
}