using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1217. 玩筹码
    /// https://leetcode-cn.com/problems/play-with-chips/
    /// </summary>

    public class Solution_1217
    {
        // method 0
        public int MinCostToMoveChips_0(int[] chips)
        {
            int odd = 0; // 奇数
            int even = 0; // 偶数
            for (int i = 0; i < chips.Length; i++)
            {
                // 偶数的新写法
                if ((chips[i] & 1) == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }
            return Math.Min(even, odd);
        }

    }
}