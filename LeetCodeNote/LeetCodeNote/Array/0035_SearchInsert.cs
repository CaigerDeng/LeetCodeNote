namespace LeetCodeNote.Array
{
    /// <summary>
    /// 35. 搜索插入位置
    /// https://leetcode-cn.com/problems/search-insert-position/
    /// </summary>
    
    public class Solution_035
    {
        // method 0 (mine)
        public int SearchInsert_0(int[] nums, int target)
        {
            if (nums[nums.Length - 1] < target)
            {
                return nums.Length;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val >= target)
                {
                    return i;
                }
            }
            return -1;
        }


        // method 1 bsearch
        public int SearchInsert_1(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            // 不取right值，是因为right可能为负数
            return left; 
        }


    }
}