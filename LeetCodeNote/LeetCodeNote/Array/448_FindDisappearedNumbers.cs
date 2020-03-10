using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 448. 找到所有数组中消失的数字
    /// https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/
    /// </summary>

    public class Solution
    {
        // method 0 
        // ...不符题目无额外空间的要求
        public IList<int> FindDisappearedNumbers_0(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                hash.Add(nums[i]);
            }
            List<int> res = new List<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!hash.Contains(i))
                {
                    res.Add(i);
                }
            }
            return res;
        }

        // method 1
        public IList<int> FindDisappearedNumbers_1(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int newIndex = Math.Abs(nums[i]) - 1;
                if (nums[newIndex] > 0)
                {
                    nums[newIndex] *= -1;
                }
            }
            List<int> res = new List<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                if (nums[i - 1] > 0)
                {
                    res.Add(i);
                }
            }
            return res;
        }








    }
}