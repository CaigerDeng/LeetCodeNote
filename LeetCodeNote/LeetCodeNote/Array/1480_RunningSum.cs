namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1480. 一维数组的动态和
    /// https://leetcode-cn.com/problems/running-sum-of-1d-array/
    /// </summary>


    public class Solution_1480
    {
        // method 0
        public int[] RunningSum_0(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }
            return nums;

        }

    }
}