using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle_AStar
{
    /// <summar>  
    /// AstarAlgorithm class
    /// </summary>
    public class AstarAlgorithm
    {
        /// <summary>
        /// contains set of operations to solve the 8-puzzle problem 
        /// </summary>
        /// <param name="_initState">Initial State given by user</param>
        /// <param name="_goalState">Goal State</param>
        public static void Solver(int[,] _initState, int[,] _goalState)
        {
            Console.WriteLine("Select Options for heuristics: 1. Manhatan Distance" + '\n' + " 2. Misplaced Tiles");
            
            int heuristic = Convert.ToInt16(Console.ReadLine());

            int _generatedChildCount = 0, _exploredChildCount = 1;

            List<State> _fringe=new List<State>();
            List<string> _operations = new List<string>();

            int[,] _currentChild = _initState;
            var _explored = new List<int[,]>();
            _explored.Add(_initState);
            while (!Helper.GoalTest(_goalState, _currentChild))
            {
                var _indexOfZero = Helper.FindIndexOfZero(_currentChild);
                var children = Operations.GenerateChildrenStates(_currentChild, _goalState, _indexOfZero.Item1, _indexOfZero.Item2);
                _generatedChildCount = _generatedChildCount + children.Count;
                if (heuristic.Equals(1))
                {
                    _fringe = children.OrderBy(o => o._manhatanDistance).ToList();
                }
                else
                {
                    _fringe = children.OrderBy(o => o._misplacedTiles).ToList();
                }
                bool flag;
                for (int i = 0; i < _fringe.Count; i++)
                {
                    flag = Helper.ExploredTest(_fringe[i], _explored);
                    if (!flag)
                    {
                        _currentChild = _fringe[i]._matrix;
                        _explored.Add(_currentChild);
                        _operations.Add(_fringe[i]._operator);
                        _exploredChildCount++;
                        break;
                    }
                }
            }
            Helper.PrintResults(_explored, _generatedChildCount, _exploredChildCount, _operations);
        }
    }
}
