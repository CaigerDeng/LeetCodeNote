namespace LeetCodeNote.Array
{
    /// <summary>
    /// 剑指 Offer 53 - II. 0～n-1中缺失的数字
    /// https://leetcode-cn.com/problems/que-shi-de-shu-zi-lcof/
    /// </summary>


    public class Solution_Offer53_MissingNumber
    {
        // method 0
        // 二分
        // https://leetcode-cn.com/problems/que-shi-de-shu-zi-lcof/solution/mian-shi-ti-53-ii-0n-1zhong-que-shi-de-shu-zi-er-f/
        public int MissingNumber_0(int[] nums)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] == mid)
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