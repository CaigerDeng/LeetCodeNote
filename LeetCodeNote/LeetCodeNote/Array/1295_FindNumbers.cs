using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1295. 统计位数为偶数的数字
    /// https://leetcode-cn.com/problems/find-numbers-with-even-number-of-digits/
    /// </summary>

    public class Solution_1295
    {
        // method 0
        public int FindNumbers_0(int[] nums)
        {
            int count = 0;
            foreach (var n in nums)
            {
                if (n.ToString().Length % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        // method 1
        // 数学公式 k-1 <= log10(x) < k，即 k = math.floor( log10(x)+1 )
        public int FindNumbers_1(int[] nums)
        {
            int count = 0;
            foreach (var n in nums)
            {
                // 都快忘了直接用int取整了
                if ((int)(Math.Log10(n) + 1) % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }



    }
}