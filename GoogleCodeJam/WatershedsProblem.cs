using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GoogleCodeJam
{
    public class Watershed
    {
        //public Point Coordinate { get; set; }
        public int Value { get; set; }
        public Point FlowCoordinate { get; set; }
        public char Identifier { get; set; }
    }
    public class WatershedsProblem : IProblem
    {
        public List<List<Watershed>> Grid { get; set; }
        public string IDENTIFIERS = "abcdefghijklmnopqrstuvwxyz";
        public int CURRENT_IDENTIFIER_INDEX = 0;

        public WatershedsProblem(List<List<Watershed>> grid)
        {
            Grid = grid;
        }

        public string Solve()
        {
            //Identify NorthWest corner: [0,0]
            Grid[0][0].Identifier = IDENTIFIERS[CURRENT_IDENTIFIER_INDEX++];

            //Identify Flow Directions

            //Flow Water from NorthWest corner

            //Identify other sinks

            //Flow water from all squares
            return "";
        }
        public void PrintGrid()
        {
            Console.WriteLine();
            foreach (var row in Grid)
            {
                foreach (var cell in row)
                    Console.Write("[{0},{1},{2}] ", 
                        cell.Value, 
                        (cell.FlowCoordinate != null) ? string.Format("({0},{1})", cell.FlowCoordinate.X, cell.FlowCoordinate.Y) 
                                                      : "( , )",
                        cell.Identifier.ToString().PadRight(1));
                Console.WriteLine();
            }
        }

        private void _identifyFlowDirections()
        {
            foreach (var row in Grid)
            {
                foreach (var cell in row)
                {

                }
            }

        }
        private IEnumerable<Point> _getNeighbors(int x, int y, int width, int height)
        {
            var neighbors = new List<Point>();
            
            //North
            if (y - 1 >= 0)
                neighbors.Add(new Point(x, y - 1));
            //West
            if (x - 1 >= 0)
                neighbors.Add(new Point(x - 1, y));
            //South
            if (y + 1 <= height)
                neighbors.Add(new Point(x, y + 1));
            //East
            if (x + 1 <= width)
                neighbors.Add(new Point(x + 1, y));
            
            
            return neighbors;
        }
        //private char _flowWater(int x, int y)
        //{

        //}
    }
}
