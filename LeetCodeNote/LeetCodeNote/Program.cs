﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LeetCodeNote.Array;
using LeetCodeNote.LinkedList;
using LeetCodeNote.Stack;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution_682 so = new Solution_682();
            // arr1 = {2,3,1,3,2,4,6,7,9,2,19}
            int[] arr1 = new int[] { 4, 1, 2 };
            int[] arr2 = new int[] { 1, 3, 4, 2 };

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

            string[] que = new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" };
            Console.WriteLine(so.CalPoints_0(que));







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
