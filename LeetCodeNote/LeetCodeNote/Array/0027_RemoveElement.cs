using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCodeNote.Array
{
    /// <summary>
    /// 27. 移除元素
    /// https://leetcode-cn.com/problems/remove-element/
    /// </summary>

    public class Solution_27
    {
        // method 0：都从索引0开始走的双指针
        public int RemoveElement_0(int[] nums, int val)
        {
            int count = 0;
            int left = 0;   // 第一个是val的索引
            int right; // 下一个待处理的数

            // 这样写有一个缺点，就是如果nums中都没有val，那就会多跑一遍没用的赋值，因此提出method 1
            for (right = 0; right < nums.Length; right++)
            {
                if (nums[right] != val)
                {
                    nums[left] = nums[right];
                    left++;
                }
            }
            // 前k个数，即left个数。
            return left;

        }

        // method 1：（对method 0的优化）从头尾各走的双指针
        public int RemoveElement_1(int[] nums, int val)
        {
            int left = 0;
            int right = nums.Length; // 注意，right是数组外的索引，如果right = nums.Length-1，则left可能少算。
            while (left < right)
            {
                if (nums[left] == val)
                {
                    nums[left] = nums[right - 1];
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return left;

        }


    }
}
