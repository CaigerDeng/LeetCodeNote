using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 剑指 Offer 53 - I. 在排序数组中查找数字 I
    /// https://leetcode-cn.com/problems/zai-pai-xu-shu-zu-zhong-cha-zhao-shu-zi-lcof/
    /// </summary>


    public class Solution_Offer53_Search
    {

        // method 0
        // 二分 + 优化
        // https://leetcode-cn.com/problems/zai-pai-xu-shu-zu-zhong-cha-zhao-shu-zi-lcof/solution/mian-shi-ti-53-i-zai-pai-xu-shu-zu-zhong-cha-zha-5/
        public int Search_0(int[] nums, int target)
        {
            return Helper(nums, target) - Helper(nums, target - 1);

        }


        // 求右边界
        private int Helper(int[] nums, int target)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] <= target)
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }
            }
            return i;

        }


    }

}