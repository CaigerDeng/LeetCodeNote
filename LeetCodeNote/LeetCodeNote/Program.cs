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
            Solution_532 so = new Solution_532();
            int[] nums1 = new[] { 1, 3, 1, 5, 4 };

            //int[] nums2 = { 2, 5, 6 };


            Console.WriteLine("res:{0}", so.FindPairs_1(nums1, 0));



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
