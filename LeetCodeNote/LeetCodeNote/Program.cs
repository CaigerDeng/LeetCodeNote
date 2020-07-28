﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LeetCodeNote.Array;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution_1331 so = new Solution_1331();
            // arr1 = {2,3,1,3,2,4,6,7,9,2,19}
            //            int[] arr1 = new int[] { 26, 21, 11, 20, 50, 34, 1, 18 };
            //int[] arr2 = new int[] { 21, 11, 26, 20 };


            //int[][] arr = new int[4][]; 
            //arr[0] = new int[] { 1, 2 };
            //arr[1] = new int[] { 2, 1 };
            //arr[2] = new int[] { 3, 4 };
            //arr[3] = new int[] { 5, 6 };

            //string[] que = new string[] { "bba", "abaaaaaa", "aaaaaa", "bbabbabaab", "aba", "aa", "baab", "bbbbbb", "aab", "bbabbaabb" };
            //string[] word = new string[] { "aaabbb", "aab", "babbab", "babbbb", "b", "bbbbbbbbab", "a", "bbbbbbbbbb", "baaabbaab", "aa" };

            //            int[][] grid = new int[3][];
            //            grid[0] = new int[] { 1, 2, 3 };
            //            grid[1] = new int[] { 4, 5, 6 };
            //            grid[2] = new int[] { 7, 8, 9 };

            int[] arr = new int[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 };
            PrintArr(so.ArrayRankTransform_0(arr));

            Console.WriteLine( );



            Console.ReadLine();

        }


        static void PrintArr(int[] arr)
        {
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
