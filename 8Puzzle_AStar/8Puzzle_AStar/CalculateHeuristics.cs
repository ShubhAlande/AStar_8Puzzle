using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle_AStar
{
    public class CalculateHeuristics
    {
        /// <summary>
        /// Calculate Manhatan distance
        /// </summary>
        /// <param name="matrix">Current tate</param>
        /// <param name="goalState">Goal State</param>
        /// <returns>The Manhattan distance for current state</returns>
        public static int ManhatanDistance(int[,] matrix,int[,] goalState)
        {
            int manhatanDistance = 0;
            int x=0, y=0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var num = matrix[i, j];
                    for (int k = 0; k < goalState.GetLength(0); k++)
                    {
                        for (int l = 0; l < goalState.GetLength(1); l++)
                        {
                            if (num == goalState[k, l])
                            {
                                x = k;
                                y = l;
                            }
                        }

                    }

                    switch (num)
                    {
                        case 1: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 2: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 3: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 4: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 5: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 6: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 7: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;
                        case 8: manhatanDistance += Math.Abs(x - i) + Math.Abs(y - j); break;

                        default:
                            break;
                    }
                }
            }

            return manhatanDistance;
        }

        /// <summary>
        /// Calculates number of misplaced tiles by comparing current state and goal state. 
        /// </summary>
        /// <param name="childMatrix">Current State</param>
        /// <param name="goalState">Goal State</param>
        /// <returns>Number of misplaced tiles</returns>
        public static int CalculateMisplacedTiles(int[,] childMatrix, int[,] goalState)
        {
            int misplacedeTiles = 0;
            for (int i = 0; i < childMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < childMatrix.GetLength(1); j++)
                {
                    if (childMatrix[i, j] != goalState[i, j] && childMatrix[i, j] != 0)
                    {
                        misplacedeTiles++;
                    }
                }
            }
            return misplacedeTiles;
        }

    }
}
