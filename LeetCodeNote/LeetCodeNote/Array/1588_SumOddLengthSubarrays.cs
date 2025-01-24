using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1588. 所有奇数长度子数组的和
    /// https://leetcode-cn.com/problems/sum-of-all-odd-length-subarrays/
    /// </summary>

    public class Solution_1588
    {
        // 以下题解来自 https://leetcode-cn.com/problems/sum-of-all-odd-length-subarrays/solution/cong-on3-dao-on-de-jie-fa-by-liuyubobobo/
        // method 0
        public int SumOddLengthSubarrays_0(int[] arr)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int sz = 1; i + sz - 1 < arr.Length; sz += 2)
                {
                    // 求从arr[i]到arr[i + sz - 1]连续子数组和
                    res += Accumulate(arr, i, i + sz - 1, 0);
                }
            }
            return res;

        }

        public int Accumulate(int[] arr, int startIndex, int endIndex, int num)
        {
            return num + arr.Where((t, i) => i >= startIndex && i <= endIndex).Sum();
        }

        // method 1
        public int SumOddLengthSubarrays_1(int[] arr)
        {
            // 利用前缀和
            int[] preSumArr = new int[arr.Length];
            preSumArr[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                preSumArr[i] = arr[i] + preSumArr[i - 1];
            }
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int sz = 1; i + sz - 1 < arr.Length; sz += 2)
                {
                    // 求从arr[i]到arr[i + sz - 1]连续子数组和
                    int val = 0;
                    if (i - 1 >= 0)
                    {
                        val = preSumArr[i - 1];
                    }
                    res += preSumArr[i + sz - 1] - val;
                }
            }
            return res;

        }

        // method 2
        // 总结出数学规律
        public int SumOddLengthSubarrays_2(int[] arr)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int left = i + 1; // 包含自身
                int right = arr.Length - i; // 包含自身
                int left_even = (left + 1) / 2;
                int left_odd = left / 2;
                int right_even = (right + 1) / 2;
                int right_odd = right / 2;
                res += (left_even * right_even + left_odd * right_odd) * arr[i];
            }
            return res;

        }



    }
}