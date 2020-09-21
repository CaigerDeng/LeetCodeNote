using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 16.17. 连续数列
    /// https://leetcode-cn.com/problems/contiguous-sequence-lcci/
    /// </summary>


    public class Solution_Face16_17
    {
        // method 0
        public int MaxSubArray_0(int[] nums)
        {
            int len = nums.Length;
            if (len == 0)
            {
                return 0;
            }
            if (len == 1)
            {
                return nums[0];
            }
            int[] arr = new int[len];
            arr[0] = nums[0];
            int max = nums[0];
            for (int i = 1; i < len; i++)
            {
                int v = nums[i];
                arr[i] = Math.Max(arr[i - 1] + v, v);
                max = Math.Max(max, arr[i]);
            }
            return max;

        }


    }


}