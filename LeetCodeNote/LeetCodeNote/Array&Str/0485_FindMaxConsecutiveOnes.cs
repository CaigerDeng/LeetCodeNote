using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 448. 找到所有数组中消失的数字
    /// https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/
    /// </summary>


    public class Solution_485
    {
        // method 0 
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    maxCount = Math.Max(count, maxCount);
                    count = 0;
                }
            }
            return Math.Max(count, maxCount);
        }

        // method 1
        // 可以用双指针法，但是和method 0意思一样，不过method 0 更好理解，所以这里就没写
        // ... 





    }
}