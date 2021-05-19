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
            Solution_703_KthLargest so = new Solution_703_KthLargest();
            // arr1 = {2,3,1,3,2,4,6,7,9,2,19}
            string[] arr1 = new String[] { "w", "wo", "wor", "worl", "world" };
            int[] arr2 = new int[] { 2, 2 };

            //            int[] arr2 = new int[] { 2, 4, 1, 3 };

            //string solu = "RGRB";
            //string guess = "BBBY";


            //int[][] arr = new int[3][];
            //arr[0] = new int[] { 1, 0, 0 };
            //arr[1] = new int[] { 0, 0, 1 };
            //arr[2] = new int[] { 1, 0, 0 };
            //arr[3] = new int[] { -2, -2, -2, -2, -3 };
            //arr[4] = new int[] { -3, -3, -3, -3, -3 };

            //string[] que = new string[] { "bba", "abaaaaaa", "aaaaaa", "bbabbabaab", "aba", "aa", "baab", "bbbbbb", "aab", "bbabbaabb" };
            //string[] word = new string[] { "aaabbb", "aab", "babbab", "babbbb", "b", "bbbbbbbbab", "a", "bbbbbbbbbb", "baaabbaab", "aa" };

            //            int[][] grid = new int[3][];
            //            grid[0] = new int[] { 1, 2, 3 };
            //            grid[1] = new int[] { 4, 5, 6 };
            //            grid[2] = new int[] { 7, 8, 9 };

                //["KthLargest","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add","add"]
                //[[7,[-10,1,3,1,4,10,3,9,4,5,1]],[3],[2],[3],[1],[2],[4],[5],[5],[6],[7],[7],[8],[2],[3],[1],[1],[1],[10],[11],[5],[6],[2],[4],[7],[8],[5],[6]]

            int k = 3;
            int[] a = new int[] { 4, 5, 8, 2 };//{-10, 1, 3, 1, 4, 10, 3, 9, 4, 5, 1};// {4, 5, 8, 2}; // { 0 }



            Solution_703_KthLargest.KthLargest_1 kth = new Solution_703_KthLargest.KthLargest_1(k, a);

            //Console.WriteLine(kth.h.GetTop());
            Console.WriteLine(kth.Add(3));
            Console.WriteLine(kth.Add(5));
            Console.WriteLine(kth.Add(10));
            Console.WriteLine(kth.Add(9));
            Console.WriteLine(kth.Add(4));

            //Console.WriteLine(kth.Add(-1));
            //Console.WriteLine(kth.Add(1));
            //Console.WriteLine(kth.Add(-2));
            //Console.WriteLine(kth.Add(-4));
            //Console.WriteLine(kth.Add(3));

            Console.ReadLine();

        }


        static void PrintArr<T>(T[] arr)
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
