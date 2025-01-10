using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    public class TestMisc
    {
        public void Run()
        {
            string[] strs = { "dog", "racecar", "car" };

            string res = strs.Min();


            Console.WriteLine("res:{0}", res);


        }

        public void Reverse(StringBuilder sb, int left, int right)
        {
            while (left < right) // 当left==right时，反转无意义，所以可以不写等于
            {
                (sb[left], sb[right]) = (sb[right], sb[left]);
                left++;
                right--;
            }

        }



    }




}
