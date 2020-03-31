using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 674. 最长连续递增序列
    /// https://leetcode-cn.com/problems/longest-continuous-increasing-subsequence/
    /// </summary>
    
    public class Solution_674
    {

        // method 0
        // 滑窗法
        public int FindLengthOfLCIS_0(int[] nums)
        {
            int len = 0;
            int startIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i - 1] >= nums[i])
                {
                    startIndex = i;
                }
                len = Math.Max(len, i - startIndex + 1);
            }
            return len;
        }
    }


}