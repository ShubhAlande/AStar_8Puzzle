using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle_AStar
{
   public class Helper
    {
        /// <summary>
        /// compare current sate with goal state
        /// </summary>
        /// <param name="_goalState">Goal State</param>
        /// <param name="matrix2">Current State</param>
        /// <returns>true if current state is goal state otherwise false</returns>
        public static bool GoalTest(int[,] _goalState, int[,] matrix2)
        {
            for (int i = 0; i < _goalState.GetLength(0); i++)
            {
                for (int j = 0; j < _goalState.GetLength(1); j++)
                {
                    if (_goalState[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Checks state with lowest heuristic exists in explored list
        /// </summary>
        /// <param name="state">State with Lowest heuristic</param>
        /// <param name="explored">List of expanded states</param>
        /// <returns>True if state is already present in explored list otherwise False</returns>
        public static bool ExploredTest(State state, List<int[,]> explored)
        {
            var stateExplored = false;

            for (int i = 0; i < explored.Count; i++)
            {

                stateExplored = JsonConvert.SerializeObject(explored[i]).Equals(JsonConvert.SerializeObject(state._matrix));
                if (stateExplored)
                {
                    break;
                }

            }
            return stateExplored;
        }

        /// <summary>
        /// Finds co-ordinates of blank tile
        /// </summary>
        /// <param name="_initState">Initial State</param>
        /// <returns>co-ordinates of blank tile</returns>
        public static Tuple<int, int> FindIndexOfZero(int[,] _initState)
        {
            int width = _initState.GetLength(0);
            int height = _initState.GetLength(1);

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (_initState[x, y].Equals(0))
                    {
                        return Tuple.Create(x, y);
                    }
                }
            }
            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// Prints solution path, nodes generated and nodes explored
        /// </summary>
        /// <param name="_explored">List of expanded states</param>
        /// <param name="_generatedChildCount">number of generated childrens</param>
        /// <param name="_exploredChildCount">number of expanded states</param>
        /// <param name="_operations">operation performed on states to achieve goal state</param>
        public static void PrintResults(List<int[,]> _explored, int _generatedChildCount, int _exploredChildCount,List<string> _operations)
        {
            for (int k = 0; k < _explored.Count; k++)
            {
                for (int i = 0; i < _explored[k].GetLength(0); i++)
                {
                    for (int j = 0; j < _explored[k].GetLength(1); j++)
                    {
                        Console.Write(string.Format("{0} ", _explored[k][i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
                //Console.Write(string.Format("Operations: {0} ", _operations[k]));
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.Write(string.Format("Number of nodes generated: {0} ", _generatedChildCount));
            Console.Write(Environment.NewLine);
            Console.Write(string.Format("Number of nodes explored: {0} ", _exploredChildCount));
            Console.ReadLine();
        }

        /// <summary>
        /// Prints 2D array accepted from user
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintArray(int[,] matrix)
        {
            Console.WriteLine("Printing Matrix: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }        

    }
}
