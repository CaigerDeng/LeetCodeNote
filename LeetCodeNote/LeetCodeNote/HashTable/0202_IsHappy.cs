using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 202. 快乐数
    /// https://leetcode.cn/problems/happy-number/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_202
    {

        public void Run()
        {
            //int n = 19;

            //int n = 2;

            int n = 6589;

            bool res = IsHappy_1( n);
            Console.WriteLine("res:{0}", res);


        }

        // (2025/2/17) method My 0-我的题解0
        // 按题意直写。用哈希表检测重复，如果出现重复数字，说明陷入无限循环。
        // 时间复杂度：O(logN)，空间复杂度：O(logN)
        public bool IsHappy_My_0(int n)
        {
            int sum = 0;
            string s = n.ToString();
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(n);
            while (sum != 1)
            {
                sum = 0;
                foreach (char c in s)
                {
                    int num = int.Parse(c.ToString());
                    sum += num * num;
                }
                if (!hashSet.Add(sum))
                {
                    break;
                }
                s = sum.ToString();
            }
            return sum == 1;

        }

        // method 1-官方题解1
        // 思路和“我的题解0”一样，只是官方获取每一位的数字的写法与我不同。
        // 官方解释了为什么数不会接近无穷大，因为即使取int上限（2^31 - 1，即2147483647），它得到的和是260，相当于把循环限制在了260之下。
        // 时间复杂度：O(logN)，空间复杂度：O(logN)
        public bool IsHappy_1(int n)
        {
            HashSet<int> seen = new HashSet<int>();
            while (n != 1 && !seen.Contains(n))
            {
                seen.Add(n);
                n = GetNext(n);
            }
            return n == 1;

        }

        private int GetNext(int n)
        {
            int totalSum = 0;
            while (n > 0)
            {
                // 如何取每一位的数
                // 比如：6589 % 10 = 9，6589 / 10 = 589。
                int d = n % 10;
                n = n / 10;
                totalSum += d * d;
            }
            return totalSum;

        }

        // method 2-官方题解2
        // 快慢指针法（龟兔赛跑）
        // 时间复杂度：O(logN)，空间复杂度：O(1)
        public bool IsHappy_2(int n)
        {
            int slow = n;
            int fast = GetNext(n); // fast比slow走快一步
            while (fast != 1 && slow != fast)
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast)); // fast比slow走快一步
            }
            return fast == 1;

        }

        // method 3-官方题解3
        // 数学。（一般都不会想到的方法）更像是算多了总结出的规律，官方给出了一个固定循环，其他数字要么在进入这个循环，要么就是快乐数。
        // 时间复杂度：O(logN)，空间复杂度：O(1)
        public bool IsHappy_3(int n)
        {
            HashSet<int> cycleMembers = new HashSet<int>(new int[8] { 4, 16, 37, 58, 89, 145, 42, 20 });
            while (n != 1 && !cycleMembers.Contains(n))
            {
                n = GetNext(n);
            }
            return n == 1;

        }

    }

}