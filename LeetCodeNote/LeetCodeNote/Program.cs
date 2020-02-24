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
            Solution_27 so = new Solution_27();
            int[] arr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            int res = so.RemoveElement(arr, 2);


            PrintArr(arr);
            Console.WriteLine("count:{0}", res);


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
