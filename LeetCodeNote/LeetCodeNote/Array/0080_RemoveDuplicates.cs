using System;
using System.Collections.Generic;
using System.Collections;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 80. 删除有序数组中的重复项 II
    /// https://leetcode.cn/problems/remove-duplicates-from-sorted-array-ii/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_80
    {

        public void Run()
        {
            //int[] nums = new[] { 1, 1, 1, 2, 2, 3 };

            int[] nums = new[] { 0, 0, 1, 1 };

            int len = RemoveDuplicates_0(nums);

            Program.PrintArr(nums);



        }



        // method 0：快慢指针   
        public int RemoveDuplicates_0(int[] nums)
        {
            // 按题意，数组大小至少为1；如果恰好只有两个元素则不用判断
            if (nums.Length <= 2)
            {
                return nums.Length;
            }
            // 慢指针：指已经处理的数组长度
            int slow = 2;
            // 快指针：指当前遍历到的元素
            int fast = 2;
            while (fast < nums.Length)
            {
                // 如果nums[slow - 2]等于nums[fast]，则必然出现过分重复元素
                // 如果nums[slow - 2]不等于nums[fast]，则必然赋值。
                // 赋值有两种情况：一可能是赋值重复元素，没关系，这个会在下一步循环中处理；二可能是赋值不同元素，此乃slow正常往后移动操作。
                if (nums[slow - 2] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;

        }



    }


}
