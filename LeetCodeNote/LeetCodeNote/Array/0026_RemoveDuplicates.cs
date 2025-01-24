using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 26. 删除排序数组中的重复项
    /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
    /// </summary>
     
    public class Solution_26
    {
        //method 0：（我的写法，和官方题解细节不同）双指针
        public int RemoveDuplicates_0(int[] nums)
        {
            // 双指针，它们都是从0开始数
            int left = 0;
            // 按题意，nums大小至少为1，所以无需判空
            int count = 1; 
            // right：待处理元素的索引
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] != nums[left])
                {
                    count++;
                    left++;
                    nums[left] = nums[right];
                }
            }
            return count;

        }

        // method 1：（官方题解）快慢指针
        public int RemoveDuplicates_1(int[] nums)
        {
            // 请注意，快慢指针都从1开始数！
            int slow = 1; // 慢指针，下一个不同元素的索引
            int fast = 1; // 快指针，指向遍历数组到达的索引
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[fast - 1])
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
