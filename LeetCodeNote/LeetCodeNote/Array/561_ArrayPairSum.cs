using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 561. 数组拆分 I
    /// https://leetcode-cn.com/problems/array-partition-i/
    /// </summary>
    /// 
    public class Solution_561
    {

        // method 0 
        // ... 看不懂官方题解
        private int maxSum = int.MinValue;

        public int ArrayPairSum_0(int[] nums)
        {
            Permute(nums, 0);
            return maxSum;
        }

        private void Permute(int[] nums, int j)
        {
            if (j == nums.Length - 1)
            {
                int sum = 0;
                for (int i = 0; i < nums.Length / 2; i++)
                {
                    sum += Math.Min(nums[i], nums[nums.Length / 2 + i]);
                }
                maxSum = Math.Max(maxSum, sum);
            }
            for (int i = j; i < nums.Length; i++)
            {
                Swap(nums, i, j);
                Permute(nums, j + 1);
                Swap(nums, i, j);
            }
        }

        private void Swap(int[] nums, int x, int y)
        {
            int temp = nums[x];
            nums[x] = nums[y];
            nums[y] = temp;
        }

        // method 1 
        public int ArrayPairSum_1(int[] nums)
        {
            System.Array.Sort(nums);
            int sum = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }
            return sum;
        }

        // method 2 
        // ... 看不懂官方题解
        public int ArrayPairSum_2(int[] nums)
        {
            int[] arr = new int[20001];
            int lim = 10000;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                arr[lim + val]++;
            }
            int d = 0;
            int sum = 0;
            for (int i = -10000; i <= 10000; i++)
            {
                sum += (arr[i + lim] + 1 - d) / 2 * i;
                d = (2 + arr[i + lim] - d) % 2;
            }
            return sum;
        }







    }
}