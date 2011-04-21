using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GoogleCodeJam
{
    public class Watershed
    {
        public Point Coordinate { get; set; }
        public int Value { get; set; }
        public Point FlowCoordinate { get; set; }
        public char Identifier { get; set; }
    }
    public class WatershedsProblem : IProblem
    {
        public List<Watershed> Grid { get; set; }
        public string IDENTIFIERS = "abcdefghijklmnopqrstuvwxyz";
        public int CURRENT_IDENTIFIER_INDEX = 0;

        public WatershedsProblem(List<List<int>> grid)
        {
            Grid = new List<Watershed>();

            int gridHeight = grid.Count;
            int gridWidth = grid[0].Count;
            for (int y = 0; y < gridHeight; y++)
                for (int x = 0; x < gridWidth; x++)
                    Grid.Add(new Watershed()
                    {
                        Coordinate = new Point(x, y),
                        Value = grid[y][x]
                    });
        }

        public string Solve()
        {
            //Identify NorthWest corner: [0,0]
            Grid.First(c => c.Coordinate == new Point(0,0)).Identifier = IDENTIFIERS[CURRENT_IDENTIFIER_INDEX++];

            //Identify Flow Directions
            _identifyFlowDirections();
            
            //Flow Water from NorthWest corner


            //Identify other sinks


            //Flow water from all squares


            PrintGrid();
            return "";
        }
        public void PrintGrid()
        {
            foreach (var cell in Grid)
            {
                if (cell.Coordinate.X == 0)
                    Console.WriteLine();

                Console.Write("[{0},{1},{2}] ", 
                    cell.Value, 
                    (cell.FlowCoordinate != null) ? string.Format("({0},{1})", cell.FlowCoordinate.X, cell.FlowCoordinate.Y) : "( , )",
                    cell.Identifier.ToString().PadRight(1));
            }
        }

        private void _identifyFlowDirections()
        {
            int gridWidth = Grid.Max(c => c.Coordinate.X);
            int gridHeight = Grid.Max(c => c.Coordinate.Y);

            IEnumerable<Point> neighbors;
            foreach (var cell in Grid)
            {
                neighbors = _getNeighbors(cell.Coordinate, gridWidth, gridHeight);
                cell.FlowCoordinate = _getFlowCoordinate(cell, neighbors);
            }
        }
        private IEnumerable<Point> _getNeighbors(Point point, int width, int height)
        {
            var neighbors = new List<Point>();
            
            //North
            if (point.Y - 1 >= 0)
                neighbors.Add(new Point(point.X, point.Y - 1));
            //West
            if (point.X - 1 >= 0)
                neighbors.Add(new Point(point.X - 1, point.Y));
            //South
            if (point.Y + 1 <= height)
                neighbors.Add(new Point(point.X, point.Y + 1));
            //East
            if (point.X + 1 <= width)
                neighbors.Add(new Point(point.X + 1, point.Y));
            
            
            return neighbors;
        }
        private Point _getFlowCoordinate(Watershed cell, IEnumerable<Point> neighbors)
        {
            int minValue = neighbors.Min(p => Grid.First(c => c.Coordinate == p).Value);
            if (minValue >= cell.Value)
                return cell.Coordinate;
            
            var eligableNeighbors = neighbors.Where(p => Grid.First(c => c.Coordinate == p).Value == minValue);

            //Eligable cells == 1
            if (eligableNeighbors.Count() == 1)
                return eligableNeighbors.First();

            //Eligable cells > 1
            //North
            if (eligableNeighbors.Any(p => p.Y == cell.Coordinate.Y - 1))
                return eligableNeighbors.First(p => p.Y == cell.Coordinate.Y - 1);
            //West
            if (eligableNeighbors.Any(p => p.X == cell.Coordinate.X - 1))
                return eligableNeighbors.First(p => p.X == cell.Coordinate.X - 1);
            //East
            if (eligableNeighbors.Any(p => p.X == cell.Coordinate.X + 1))
                return eligableNeighbors.First(p => p.X == cell.Coordinate.X + 1);
            //South
            if (eligableNeighbors.Any(p => p.Y == cell.Coordinate.Y + 1))
                return eligableNeighbors.First(p => p.Y == cell.Coordinate.Y + 1);

            return new Point(-1, -1);
        }
    }
}
