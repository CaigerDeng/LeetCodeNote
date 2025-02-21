using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LeetCodeNote.Array;
using LeetCodeNote.HashTable;
using LeetCodeNote.Heap;
using LeetCodeNote.LinkedList;
using LeetCodeNote.Stack;

namespace LeetCodeNote
{
    public class Program
    {
        static void Main(string[] args)
        {

            //TestMisc t = new TestMisc();
            //t.Run();

            Solution_57 a = new Solution_57();
            a.Run();


            Console.WriteLine();
            Console.WriteLine("-------------------- Program end");
            Console.ReadLine();

        }


        public static void PrintArr<T>(T[] arr)
        {
            if (arr == null)
            {
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine("\n");
        }

        public static void PrintList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine("\n");
        }

        public static void PrintMatrix<T>(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + ", ");
                }
                Console.WriteLine();
            }

        }


    }



}
