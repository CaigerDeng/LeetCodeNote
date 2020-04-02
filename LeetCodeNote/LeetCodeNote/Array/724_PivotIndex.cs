namespace LeetCodeNote.Array
{
    /// <summary>
    /// 724. 寻找数组的中心索引
    /// https://leetcode-cn.com/problems/find-pivot-index/
    /// </summary>

    public class Solution_724
    {
        // method 0
        public int PivotIndex(int[] nums)
        {
            int sum = 0;
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == sum - leftSum - nums[i])
                {
                    return i;
                }
                leftSum += nums[i];
            }
            return -1;
        }










    }


}