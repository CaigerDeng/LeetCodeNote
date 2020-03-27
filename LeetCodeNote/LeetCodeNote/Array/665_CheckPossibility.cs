using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 665. 非递减数列
    /// https://leetcode-cn.com/problems/non-decreasing-array/
    /// </summary>

    public class Solution_665
    {
        // method 0
        public bool CheckPossibility_0(int[] nums)
        {
            int[] copy = new int[nums.Length];
            System.Array.Copy(nums, copy, nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                int old = nums[i];
                // 原先写成copy[i] = (i == 0) ? old - 1 : copy[i - 1];，这样是不对的，因为old - 1可能仍大于copy[i + 1]
                copy[i] = (i == 0) ? int.MinValue : copy[i - 1];
                if (IsNoIncreasing(copy))
                {
                    return true;
                }
                copy[i] = old;
            }
            return false;
        }

        private bool IsNoIncreasing(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        // method 1
        // 在method 0的基础上，尽可能缩小检测区间
        public bool CheckPossibility_1(int[] nums)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i + 2 < nums.Length && nums[i] <= nums[i + 1] && nums[i + 1] <= nums[i + 2])
            {
                i++;
            }
            while (j - 2 >= 0 && nums[j - 2] <= nums[j - 1] && nums[j - 1] <= nums[j])
            {
                j--;
            }
            int distance = j - i + 1;
            if (distance <= 2)
            {
                // 2的情况意味着i和j相邻，如[5, 7]或[7, 5]，这时候只需要修改一个数就ok
                // 2都可以直接判断，那比2小的情况，那肯定ok；
                // 如[1, 2, 3, 4, 5]，最后i，j是一个数
                // 如[1, 2, 3, 4, 5, 6]，最后j在i前面；
                return true;
            }
            if (distance >= 5)
            {
                // 5的情况意味着，i+2和j-2是一个数，这个数都让i,j无法前进，如[5, 6, 4, 2, 3]
                // 5都无法前进，那比5大，肯定也不行
                return false;
            }
            int[] res = new int[distance];
            System.Array.Copy(nums, i, res, 0, distance);
            return CheckPossibility_0(res);

        }

        // method 2
        public bool CheckPossibility_2(int[] nums)
        {
            int? p = null;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (p != null) //说明又出现了一个数
                    {
                        return false;
                    }
                    p = i;
                }
            }
            return p == null || p == 0 || p == nums.Length - 2 || nums[p.Value - 1] <= nums[p.Value + 1] || nums[p.Value] <= nums[p.Value + 2];
        }




    }
}