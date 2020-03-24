using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCodeNote.Array;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution_643 so = new Solution_643();
            int[] nums1 = new[] { 1, 12, -5, -6, 50, 3 };

            //int[] nums2 = { 2, 5, 6 };


            //            int[,] nums = new int[,] { {1, 2}, {3, 4}, {5, 6} };
            //            Console.WriteLine("{0}, {1}, {2}", nums.Length, nums.GetLength(0), nums.GetLength(1));

            //int[][] arr = new int[2][];
            //arr[0] = new int[] { 1, 2 };
            //arr[1] = new int[] { 3, 4 };


            //arr[1] = new int[] { 3, 4 };
            //Console.WriteLine("{0}, {1}, {2}", arr.Length, arr[0].Length, arr[1].Length);




            Console.WriteLine("res:{0}", so.FindMaxAverage_0(nums1, 4));



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






    }



}
