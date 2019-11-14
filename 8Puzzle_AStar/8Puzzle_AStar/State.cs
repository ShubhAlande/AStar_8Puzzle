using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle_AStar
{
    public class State
    {
        public int[,] _matrix { get; set; }
        public int _manhatanDistance { get; set; }
        public int _misplacedTiles { get; set; }
        public string _operator { get; set; }

        public State(int[,] _matrix, int _manhatanDistance,int _misplacedTiles,string _operator )
        {
            this._matrix = _matrix;
            this._manhatanDistance = _manhatanDistance;
            this._misplacedTiles = _misplacedTiles;
            this._operator = _operator;
        }
    }
}
