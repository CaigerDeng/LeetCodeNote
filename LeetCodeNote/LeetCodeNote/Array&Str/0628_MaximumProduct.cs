using System;
using System.Net.Security;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 605. 种花问题
    /// https://leetcode-cn.com/problems/can-place-flowers/
    /// </summary>

    public class Solution_628
    {
        // method 0
        public int MaximumProduct_0(int[] nums)
        {
            System.Array.Sort(nums);
            int value0 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
            int value1 = nums[0] * nums[1] * nums[nums.Length - 1];
            return Math.Max(value0, value1);
        }

        // method 1
        // 优化method 0排序
        public int MaximumProduct_1(int[] nums)
        {
            // min1 < min2 < max3 < max2 < max1
            int min1 = Int32.MaxValue;
            int min2 = Int32.MaxValue;
            int max3 = Int32.MinValue;
            int max2 = Int32.MinValue;
            int max1 = Int32.MinValue;
            foreach (int n in nums)
            {
                if (n <= min1)
                {
                    min2 = min1;
                    min1 = n;
                }
                else if (n <= min2)
                {
                    min2 = n;
                }
                if (n >= max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = n;
                }
                else if (n >= max2)
                {
                    max3 = max2;
                    max2 = n;
                }
                else if (n >= max3)
                {
                    max3 = n;
                }
            }
            int value0 = max3 * max2 * max1;
            int value1 = min1 * min2 * max1;
            return Math.Max(value0, value1);
        }





    }








}