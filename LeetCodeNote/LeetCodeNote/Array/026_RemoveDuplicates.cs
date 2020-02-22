using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 26. 删除排序数组中的重复项
/// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
/// </summary>
namespace LeetCodeNote.Array
{
    public class Solution_26
    {
        //method 0 
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
