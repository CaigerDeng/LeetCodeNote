using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 643. 子数组最大平均数 I
    /// https://leetcode-cn.com/problems/maximum-average-subarray-i/
    /// </summary>

    public class Solution_643
    {
        // method 0
        // 记录连续数组和
        // 针对原题解有优化：因为连续数组和最大那肯定平均数最大，可以到最后再除以k
        public double FindMaxAverage_0(int[] nums, int k)
        {
            int[] sum = new int[nums.Length];
            sum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum[i] = sum[i - 1] + nums[i];
            }
            double res = sum[k - 1] * 1.0;  // 编译器会认为1.0是double类型
            for (int i = k; i < nums.Length; i++)
            {
                res = Math.Max(res, (sum[i] - sum[i - k]) * 1.0);
            }
            return res / k * 1.0;
        }

        // method 1
        // 滑窗
        public double FindMaxAverage_1(int[] nums, int k)
        {
            double sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            double res = sum;
            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - nums[i - k];
                res = Math.Max(res, sum);
            }
            return res / k;
        }





    }


}