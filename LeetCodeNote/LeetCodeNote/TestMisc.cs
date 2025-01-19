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
            string needle = "aaa";
            int[] pi = new int[needle.Length];
            for (int i = 1, j = 0; i < needle.Length; i++)
            {
                while (j > 0 && needle[i] != needle[j])
                {
                    // j退回到上一个匹配索引，最多退回到起点
                    j = pi[j - 1];
                }

                if (needle[i] == needle[j])
                {
                    j++;
                }
                pi[i] = j;
            }


            Console.WriteLine("res:{0}", 0);


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
