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
            Solution_217 so = new Solution_217();
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            so.ContainsDuplicate_0(nums1);



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
