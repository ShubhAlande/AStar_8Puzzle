using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle_AStar
{
    public class Operations
    {
        /// <summary>
        /// Generates successors for current state
        /// </summary>
        /// <param name="initState">current state</param>
        /// <param name="goalState">goal state</param>
        /// <param name="x">x co-ordinate of blank tile</param>
        /// <param name="y">y co-ordinate of blank tile</param>
        /// <returns> List of generated children</returns>
        public static List<State> GenerateChildrenStates(int[,] initState,int[,] goalState, int x, int y)
        {
            var children = new List<State>();

            var rightState = MoveToTheRight(initState, goalState, x, y);
            if (rightState != null)
            {
                rightState._operator = "Right";
                children.Add(rightState);
            }

            var leftState = MoveToTheLeft(initState, goalState, x, y);
            if (leftState != null)
            {
                leftState._operator = "Left";
                children.Add(leftState);
            }

            var upState = MoveToUp(initState, goalState, x, y);
            if (upState != null)
            {
                upState._operator = "Up";
                children.Add(upState);
            }

            var downState = MoveToDown(initState, goalState, x, y);
            if (downState != null)
            {
                downState._operator = "Down";
                children.Add(downState);
            }
            
            return children;
        }      

        private static int[,] CopyMatrix(int[,] initState)
        {
            var childMatrix = new int[3,3];
            for (int i = 0; i < initState.GetLength(0); i++)
            {
                for (int j = 0; j < initState.GetLength(1); j++)
                {
                    childMatrix[i, j] = initState[i, j];
                }
            }

            return childMatrix;
        }

        private static State MoveToTheRight(int[,] initState, int[,] goalState, int x, int y)
        {

            if (y == (initState.Length / 3) - 1)
            {
                return null;
            }

            var childMatrix = CopyMatrix(initState);

            var temp = childMatrix[x, y + 1];
            childMatrix[x, y + 1] = 0;
            childMatrix[x, y] = temp;

            int manhatanDistance = CalculateHeuristics.ManhatanDistance(childMatrix, goalState);
            int misplacedeTiles = CalculateHeuristics.CalculateMisplacedTiles(childMatrix, goalState);
            return new State(childMatrix, manhatanDistance, misplacedeTiles,"");
        }

        private static State MoveToTheLeft(int[,] initState, int[,] goalState, int x, int y)
        {

            if (y == 0)
            {
                return null;
            }

            var childMatrix = CopyMatrix(initState);

            var temp = childMatrix[x, y - 1];
            childMatrix[x, y - 1] = 0;
            childMatrix[x, y] = temp;
            int manhatanDistance = CalculateHeuristics.ManhatanDistance(childMatrix, goalState);
            int misplacedeTiles = CalculateHeuristics.CalculateMisplacedTiles(childMatrix, goalState);
            return new State(childMatrix, manhatanDistance, misplacedeTiles,"");
        }
        private static State MoveToUp(int[,] initState, int[,] goalState, int x, int y)
        {
            if (x == 0)
            {
                return null;
            }

            var childMatrix = CopyMatrix(initState);

            var temp = childMatrix[x - 1, y];
            childMatrix[x - 1, y] = 0;
            childMatrix[x, y] = temp;
            int manhatanDistance = CalculateHeuristics.ManhatanDistance(childMatrix, goalState);
            int misplacedeTiles = CalculateHeuristics.CalculateMisplacedTiles(childMatrix, goalState);
            return new State(childMatrix, manhatanDistance, misplacedeTiles,"");
        }
        private static State MoveToDown(int[,] initState, int[,] goalState, int x, int y)
        {

            if (x == (initState.Length / 3) - 1)
            {
                return null;
            }

            var childMatrix = CopyMatrix(initState);

            var temp = childMatrix[x + 1, y];
            childMatrix[x + 1, y] = 0;
            childMatrix[x, y] = temp;
            int manhatanDistance = CalculateHeuristics.ManhatanDistance(childMatrix, goalState);
            int misplacedeTiles = CalculateHeuristics.CalculateMisplacedTiles(childMatrix, goalState);
            return new State(childMatrix, manhatanDistance, misplacedeTiles,"");
        }

    }
}
