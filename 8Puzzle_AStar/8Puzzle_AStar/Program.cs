using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _8Puzzle_AStar
{
    class Program
    {
        
        public static int[,] _initState=new int[3,3];
        public static int[,] _goalState = new int[3, 3];    
       
        static void Main(string[] args)
        {
                                
            Console.WriteLine("enter the numbers for Initial State");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _initState[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }

            Helper.PrintArray(_initState);

            Console.WriteLine("enter the numbers for Goal State");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _goalState[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }

            Helper.PrintArray(_goalState);

            AstarAlgorithm.Solver(_initState, _goalState);
           
        }     
    }
}
