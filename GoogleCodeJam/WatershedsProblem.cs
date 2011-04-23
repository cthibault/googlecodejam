using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GoogleCodeJam
{
    public class Watershed
    {
        public const char EMPTY_IDENTIFIER = ' ';

        public Point Coordinate { get; set; }
        public int Value { get; set; }
        public Point FlowCoordinate { get; set; }
        public char Identifier { get; set; }
        public bool IsIdentified
        {
            get { return Identifier != EMPTY_IDENTIFIER; }
        }
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
                        Value = grid[y][x],
                        Identifier = Watershed.EMPTY_IDENTIFIER
                    });
        }

        public string Solve()
        {
            //Identify NorthWest corner: [0,0]
            Grid.First(c => c.Coordinate == new Point(0,0)).Identifier = IDENTIFIERS[CURRENT_IDENTIFIER_INDEX++];

            //Identify Flow Directions
            _identifyFlowDirections();
            
            //Flow Water from NorthWest corner
            _flowWater(Grid.First(c => c.Coordinate == new Point(0, 0)), null);

            //Identify other sinks
            _identifySinks();

            //Flow water from all squares
            foreach (var c in Grid.Where(c => !c.IsIdentified))
                _flowWater(c, null);

            return _getOutput();
        }
        public void PrettyPrintGrid()
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
        private void _identifySinks()
        {
            int yMin;
            var sinks = Grid.Where(c => !c.IsIdentified && (c.FlowCoordinate == c.Coordinate));
            while (sinks.Count() > 0)
            {
                yMin = sinks.Min(c => c.Coordinate.Y);
                var cell = sinks.Where(c => c.Coordinate.Y == yMin).OrderBy(c => c.Coordinate.X).First();
                cell.Identifier = IDENTIFIERS[CURRENT_IDENTIFIER_INDEX++];
            }

            //foreach (var c in Grid.Where(c => !c.IsIdentified && (c.FlowCoordinate == c.Coordinate)))
            //    c.Identifier = IDENTIFIERS[CURRENT_IDENTIFIER_INDEX++];
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
            if (neighbors.Count() == 0)
                return cell.Coordinate;

            int minValue = neighbors.Min(p => Grid.FirstOrDefault(c => c.Coordinate == p).Value);
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

        private void _flowWater(Watershed newCell, Watershed oldCell)
        {
            if (oldCell == null)
                _flowWater(Grid.First(c => c.Coordinate == newCell.FlowCoordinate), newCell);
            else if (!newCell.IsIdentified && oldCell.IsIdentified)
            {
                newCell.Identifier = oldCell.Identifier;
                _flowWater(Grid.First(c => c.Coordinate == newCell.FlowCoordinate), newCell);
            }
            else if (newCell.IsIdentified && !oldCell.IsIdentified)
                oldCell.Identifier = newCell.Identifier;
            else if (!newCell.IsIdentified && !oldCell.IsIdentified)
            {
                _flowWater(Grid.First(c => c.Coordinate == newCell.FlowCoordinate), newCell);
                oldCell.Identifier = newCell.Identifier;
            }
        }
        private string _getOutput()
        {
            StringBuilder builder = new StringBuilder();
            int height = Grid.Max(c => c.Coordinate.Y);
            int width = Grid.Max(c => c.Coordinate.X);

            for (int y = 0; y <= height; y++)
            {
                builder.AppendLine();
                for (int x = 0; x <= width; x++)
                    builder.Append(string.Format("{0}{1}",
                        Grid.First(c => c.Coordinate == new Point(x, y)).Identifier,
                        (x != width) ? " " : string.Empty));
            }
            return builder.ToString();
        }
    }
}
