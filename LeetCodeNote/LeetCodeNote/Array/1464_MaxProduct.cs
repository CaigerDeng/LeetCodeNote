namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1464. 数组中两元素的最大乘积
    /// https://leetcode-cn.com/problems/maximum-product-of-two-elements-in-an-array/
    /// </summary>

    public class Solution_1464
    {
        // method 0
        public int MaxProduct_0(int[] nums)
        {
            System.Array.Sort(nums);
            return (nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1);

        }






    }








}