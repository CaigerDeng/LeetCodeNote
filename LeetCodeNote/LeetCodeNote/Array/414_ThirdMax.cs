namespace LeetCodeNote.Array
{

    /// <summary>
    /// 414. 第三大的数
    /// https://leetcode-cn.com/problems/third-maximum-number/
    /// </summary>

    public class Solution_414
    {
        // method 0 (mine)
        // 排序
        public int ThirdMax_0(int[] nums)
        {
            System.Array.Sort(nums);
            System.Array.Reverse(nums);
            int times = 1;
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val < max)
                {
                    max = val;
                    times++;
                }
                if (times == 3)
                {
                    return val;
                }
            }
            return nums[0];
        }

        // method 1
        public int ThirdMax_1(int[] nums)
        {
            int? max1 = null; // 第一次使用int?
            int? max2 = null;
            int? max3 = null;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (max1 == null || val > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = val;
                }
                else if (val < max1 && (max2 == null || val > max2))
                {
                    max3 = max2;
                    max2 = val;
                }
                else if (val < max2 && (max3 == null || val > max3))
                {
                    max3 = val;
                }
            }
            return max3 == null ? (int)max1 : (int)max3;
        }







    }
}