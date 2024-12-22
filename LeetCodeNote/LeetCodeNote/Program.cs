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
    class Program
    {
        static void Main(string[] args)
        {

            Solution_55 a = new Solution_55();
            a.Run();



            Console.WriteLine("--------------------end");
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

        static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine("\n");
        }

        static void TestStaggeredArray()
        {
            int[][] arr = new int[5][]; // 5代表有arr[0]，arr[1]，arr[2]，arr[3]，arr[4]
            arr[0] = new int[] { 1, 2, 3, 4 };
            arr[1] = new int[] { 3, 4, 5 };
            Console.WriteLine("{0}, {1}, {2}", arr.Length, arr[0].Length, arr[1].Length); // 输出：5, 4, 3 

        }



    }



}
