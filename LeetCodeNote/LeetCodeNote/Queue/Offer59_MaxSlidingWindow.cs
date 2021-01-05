using System.Collections.Generic;

namespace LeetCodeNote.Queue
{

    /// <summary>
    /// 剑指 Offer 59 - I. 滑动窗口的最大值
    /// https://leetcode-cn.com/problems/hua-dong-chuang-kou-de-zui-da-zhi-lcof/
    /// </summary>

    public class Solution_Offer59_MaxSlidingWindow
    {
        // method 0
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
            {
                return new int[0];
            }
            // 单调递减列表，列表大小最大为k
            List<int> list = new List<int>();
            int[] res = new int[nums.Length - k + 1];
            // 未形成窗口
            for (int i = 0; i < k; i++)
            {
                while (list.Count > 0 && list[list.Count - 1] < nums[i])
                {
                    list.RemoveAt(list.Count - 1);
                }
                list.Add(nums[i]);
            }
            res[0] = list[0];
            // 形成窗口后
            for (int i = k; i < nums.Length; i++)
            {
                if (list[0] == nums[i - k] )
                {
                    // 保持窗口大小
                    list.RemoveAt(0);
                }
                while (list.Count > 0 && list[list.Count - 1] < nums[i])
                {
                    list.RemoveAt(list.Count - 1);
                }
                list.Add(nums[i]);
                res[i - k + 1] = list[0];
            }
            return res;

        }

    }


}