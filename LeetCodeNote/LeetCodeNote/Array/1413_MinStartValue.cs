using System;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1413. 逐步求和得到正数的最小值
    /// https://leetcode-cn.com/problems/minimum-value-to-get-positive-step-by-step-sum/
    /// </summary>

    public class Solution_1413
    {
        // method 0
        // 动态规划
        public int MinStartValue_0(int[] nums)
        {
            int[] arr = new int[nums.Length];
            System.Array.Copy(nums, arr, nums.Length);
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] += arr[i - 1];
            }
            int min = arr.Min();
            return min >= 0 ? 1 : Math.Abs(min) + 1;

        }









    }


}