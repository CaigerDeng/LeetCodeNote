namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 08.03. 魔术索引
    /// https://leetcode-cn.com/problems/magic-index-lcci/
    /// </summary>


    public class Solution_Face08_03
    {

        // method 0
        public int FindMagicIndex_0(int[] nums)
        {
            return GetAnswer(nums, 0, nums.Length - 1);

        }

        private int GetAnswer(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }
            int mid = left + (right - left) / 2;
            int leftAnswer = GetAnswer(nums, left, mid - 1);
            if (leftAnswer != -1)
            {
                return leftAnswer;
            }
            else if (mid == nums[mid])
            {
                return mid;
            }            
            return GetAnswer(nums, mid + 1, right);

        }


    }

}