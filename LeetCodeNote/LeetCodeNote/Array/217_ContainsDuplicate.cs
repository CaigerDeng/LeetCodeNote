using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 217. 存在重复元素
    /// https://leetcode-cn.com/problems/contains-duplicate/
    /// </summary>
    public class Solution_217
    {
        // method 0 (mine)
        public bool ContainsDuplicate_0(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (!hash.Contains(val))
                {
                    hash.Add(val);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        // method 1 
        // 超出时间限制
        public bool ContainsDuplicate_1(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // method 2
        // 先排序
        public bool ContainsDuplicate_2(int[] nums)
        {
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        // method 3
        // same as mine
        public bool ContainsDuplicate_3(int[] nums)
        {
            //...
            return false;
        }






    }
}