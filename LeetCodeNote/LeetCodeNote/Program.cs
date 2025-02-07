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

            Solution_15 a = new Solution_15();
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

        public static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine("\n");
        }

       


    }



}
