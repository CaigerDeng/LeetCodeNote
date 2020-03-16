using System;
using System.Collections.Generic;


namespace LeetCodeNote.Array
{
    /// <summary>
    /// 532. 数组中的K-diff数对
    /// https://leetcode-cn.com/problems/k-diff-pairs-in-an-array/
    /// </summary>
    public class Solution_532
    {
        // 给定一个整数数组和一个整数 k, 你需要在数组里找到不同的 k-diff 数对。这里将 k-diff 数对定义为一个整数对 (i, j), 其中 i 和 j 都是数组中的数字，且两数之差的绝对值是 k.        
        // 发现题目理解错误，“i 和 j 都是数组中的数字”，不是指索引；
        // “不同”意味着比如[1, 1, 1, 2, 2, 3]中，[1, 1]是有且仅有一组，尽管有3个1

        // method 0 
        public int FindPairs_0(int[] nums, int k)
        {
            if (nums.Length < 2 || k < 0)
            {
                return 0;
            }
            int res = 0;
            // 原题解用的是temp = nums[0] - 1，保证temp初始值和nums[0]不同
            // 我之前设为temp = nums[0]，觉得用负数更好理解，但发现0的负数就是0，所以用负数不行
            int temp = nums[0] - 1;
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i != 0 && nums[i] == temp)
                {
                    continue; // 跳过重复                  
                }
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int val = nums[j] - nums[i]; //因为已经排序，所以val肯定是正数
                    if (val > k)
                    {
                        break; // 如果差值都已经大于k，那后面的差值只会更大
                    }
                    if (val == k)
                    {
                        res++;
                        break; // 即使后面还有重复值，根据题意“不同”的要求，就没有前进的必要
                    }
                }
                temp = nums[i];  // 重复检测记录
            }
            return res;
        }

        // method 1 
        public int FindPairs_1(int[] nums, int k)
        {
            if (nums.Length < 2 || k < 0)
            {
                return 0;
            }           
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic[num] = 0;
                }
                dic[num]++;
            }
            int res = 0;
            foreach (var item in dic)
            {
                if (k == 0)
                {
                    if (item.Value > 1)
                    {
                        res++;
                    }
                }
                else
                {
                    if (dic.ContainsKey(item.Key + k))
                    {
                        res++;
                    }
                }
            }
            return res;
        }











    }
}