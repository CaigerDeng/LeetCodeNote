using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 17.04. 消失的数字
    /// https://leetcode-cn.com/problems/missing-number-lcci/
    /// 题解可参考 268. 缺失数字
    /// https://leetcode-cn.com/problems/missing-number/
    /// </summary>

    public class Solution_Face17_04
    {
        // method 0
        public int MissingNumber_0(int[] nums)
        {
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i)
                {
                    return i;
                }
            }
            return nums[nums.Length - 1] + 1;

        }

        // method 1
        public int MissingNumber_1(int[] nums)
        {
            int sum1 = nums.Sum();
            int len = nums.Length;
            int sum2 = len * (len + 1) / 2;
            return sum2 - sum1;

        }


    }


}