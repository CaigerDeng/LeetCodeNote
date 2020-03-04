using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 219. 存在重复元素 II
    /// https://leetcode-cn.com/problems/contains-duplicate-ii/
    /// </summary>
    public class Solution_219_
    {
        // method 0 
        // 滑窗算法（什么是滑窗：https://www.zhihu.com/question/314669016）
        // 超出时间限制
        public bool ContainsNearbyDuplicate_0(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // method 1
        // SortedSet是用红黑树实现的
        // 依然是滑窗算法，但用SortedSet优化了method 0的查找速度
        // 超出时间限制
        public bool ContainsNearbyDuplicate_1(int[] nums, int k)
        {
            SortedSet<int> set = new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (set.Contains(val))
                {
                    return true;
                }
                set.Add(val);
                if (set.Count > k)
                {
                    set.Remove(nums[i - k]);
                }
            }
            return false;
        }

        // method 2
        // 散列表 dic
        // method 1的优化，将搜索速度提升
        public bool ContainsNearbyDuplicate_2(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (set.Contains(val))
                {
                    return true;
                }
                set.Add(val);
                if (set.Count > k)
                {
                    set.Remove(nums[i - k]);
                }
            }
            return false;
        }





    }
}