using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 剑指 Offer 03. 数组中重复的数字
    /// https://leetcode-cn.com/problems/shu-zu-zhong-zhong-fu-de-shu-zi-lcof/
    /// </summary>


    public class Solution_Offer_03
    {
        // method 0
        // 暴力
        public int FindRepeatNumber_0(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int k = nums[i];
                if (!hs.Contains(k))
                {
                    hs.Add(k);
                }
                else
                {
                    return k;
                }
            }
            return -1;

        }

        // method 1
        // 原地 交换（会改原数组）
        // https://leetcode-cn.com/problems/shu-zu-zhong-zhong-fu-de-shu-zi-lcof/solution/java-de-4chong-jie-fa-by-sdwwld/
        public int FindRepeatNumber_1(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums[i])
                {
                    continue;
                }
                if (nums[i] == nums[nums[i]])
                {
                    return nums[i];
                }
                int temp = nums[nums[i]];
                nums[nums[i]] = nums[i];
                nums[i] = temp;
                // 这里的i--是为了抵消掉上面的i++，
                // 交换之后需要原地再比较
                i--;
            }
            return -1;

        }


    }


}