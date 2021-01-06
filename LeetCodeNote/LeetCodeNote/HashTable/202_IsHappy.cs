using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 202. 快乐数
    /// https://leetcode-cn.com/problems/happy-number/
    /// </summary>

    public class Solution_202_IsHappy
    {

        // method 0
        public bool IsHappy_0(int n)
        {
            HashSet<int> seen = new HashSet<int>();
            while (n != 1 && seen.Contains(n))
            {
                seen.Add(n);
                n = GetNext(n);
            }
            return n == 1;

        }

        private int GetNext(int n)
        {
            int totalSum = 0;
            // 在n算完所有位数后停下
            while (n > 0)
            {
                int d = n % 10;
                n = n / 10;
                totalSum += d * d;
            }
            return totalSum;

        }

        // method 1
        public bool IsHappy_1(int n)
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

        // method 2
        public bool IsHappy_2(int n)
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