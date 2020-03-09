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
            Solution_414 so = new Solution_414();
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 2, 5, 6 };
            Console.WriteLine("res:{0}", so.ThirdMax_0(nums1));



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
