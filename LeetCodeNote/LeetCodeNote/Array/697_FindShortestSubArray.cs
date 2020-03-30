using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 697. 数组的度
    /// https://leetcode-cn.com/problems/degree-of-an-array/
    /// </summary>

    public class Solution_697
    {
        // method 0
        public int FindShortestSubArray_0(int[] nums)
        {
            Dictionary<int, int> left = new Dictionary<int, int>();
            Dictionary<int, int> right = new Dictionary<int, int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (!left.ContainsKey(val))
                {
                    left[val] = i;
                }
                right[val] = i;
                if (!count.ContainsKey(val))
                {
                    count[val] = 0;
                }
                count[val] += 1;
            }
            int len = nums.Length;
            int degree = count.Max(item => item.Value);
            foreach (var k in count.Keys)
            {
                if (count[k] == degree)
                {
                    len = Math.Min(len, right[k] - left[k] + 1);
                }
            }
            return len;
        }


    }




}