using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1608. 特殊数组的特征值
    /// https://leetcode-cn.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
    /// </summary>

    public class Solution_1608
    {
        // method 0
        // mine
        public int SpecialArray_0(int[] nums)
        {
            int[] data = new int[1001];
            foreach (var v in nums)
            {
                data[v]++;
            }
            int res = -1;
            for (int i = 0; i <= nums.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < i; j++)
                {
                    count += data[j];
                }
                if (nums.Length - count == i)
                {
                    res = i;
                    break;
                }
            }
            return res;

        }

        // method 1
        // https://leetcode-cn.com/problems/special-array-with-x-elements-greater-than-or-equal-x/solution/bao-li-pai-xu-ji-shu-san-chong-fang-fa-by-lucifer1/
        public int SpecialArray_1(int[] nums)
        {
            int n = nums.Length;
            int[] arr = new int[n + 1];
            foreach (var num in nums)
            {
                arr[Math.Min(num, n)]++;

            }
            for (int i = n; i >= 0; i--)
            {
                if (i < n)
                {
                    arr[i] += arr[i + 1];
                }
                if (arr[i] == i)
                {
                    return i;
                }               
            }
            return -1;

        }


    }


}