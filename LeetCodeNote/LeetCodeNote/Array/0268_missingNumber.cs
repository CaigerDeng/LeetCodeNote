using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 268. 缺失数字
    /// https://leetcode-cn.com/problems/missing-number/
    /// </summary>

    public class Solution_268
    {
        // method 0
        public int MissingNumber_0(int[] nums)
        {
            System.Array.Sort(nums);
            if (nums[nums.Length - 1] != nums.Length)
            {
                return nums.Length;
            }
            if (nums[0] != 0)
            {
                return 0;
            }
            for (int i = 1; i < nums.Length; i++)
            {
                int expectedNum = nums[i - 1] + 1;
                if (nums[i] != expectedNum)
                {
                    return expectedNum;
                }
            }
            return -1;
        }


        // method 1
        public int MissingNumber_1(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                hash.Add(nums[i]);
            }
            int expectedCount = nums.Length + 1;
            for (int i = 0; i < expectedCount; i++)
            {
                if (!hash.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }

        // method 2
        // 运行了解答才发现我题目理解错了
        // “给定一个包含 0, 1, 2, ..., n 中 n 个数的序列，找出 0 .. n 中没有出现在序列中的那个数。”
        // 题目意思是从0按顺序数到n应该有n+1个数，而序列只有n个数，意味着肯定丢了一个数
        // 比如[0, 1, 2]有3个数，n为3，则丢失的数是3.
        public int MissingNumber_2(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                missing ^= i ^ nums[i];
            }
            return missing;
        }

        // method 3
        public int MissingNumber_3(int[] nums)
        {
            int expectedSum = nums.Length * (nums.Length + 1) / 2;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return expectedSum - sum;
        }




















    }
}