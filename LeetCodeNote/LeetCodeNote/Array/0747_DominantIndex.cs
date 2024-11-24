namespace LeetCodeNote.Array
{
    /// <summary>
    /// 747. 至少是其他数字两倍的最大数
    /// https://leetcode-cn.com/problems/largest-number-at-least-twice-of-others/
    /// </summary>

    public class Solution_747
    {
        // method 0
        // mine：找到最大的两个数，如果第一大的数比第二大的数的2倍还大，则为true
        public int DominantIndex_0(int[] nums)
        {
            // max1 > max2
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val >= max1)
                {
                    max2 = max1;
                    max1 = val;
                    index = i;
                }
                else if (val >= max2)
                {
                    max2 = val;
                }
            }
            if (max1 < max2 * 2)
            {
                index = -1;
            }
            return index;
        }

        // method 1
        public int DominantIndex_1(int[] nums)
        {
            int maxIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > nums[maxIndex])
                {
                    maxIndex = i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (maxIndex != i && nums[maxIndex] < 2 * nums[i])
                {
                    return -1;
                }
            }
            return maxIndex;
        }





    }






}