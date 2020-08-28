using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1539. 第 k 个缺失的正整数
    /// https://leetcode-cn.com/problems/kth-missing-positive-number/
    /// </summary>


    public class Solution_1539
    {
        // method 0
        // 枚举
        public int FindKthPositive_0(int[] arr, int k)
        {
            int missCount = 0;
            int lastMiss = -1;
            int curr = 1;
            int index = 0;
            for (missCount = 0; missCount < k; curr++)
            {
                if (curr == arr[index])
                {
                    index = index + 1 < arr.Length ? index + 1 : index;
                }
                else
                {
                    missCount++;
                    lastMiss = curr;
                }
            }
            return lastMiss;

        }

        // method 1
        // 二分：依据k的公式限定范围
        public int FindKthPositive_1(int[] arr, int k)
        {
            // 如果arr[0] = k，还是要计算的
            if (arr[0] > k)
            {
                return k;
            }
            int left = 0;
            int right = arr.Length - 1;
            // 没写成left <= right，是因为就是要用left = right这个条件跳出循环
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int x = mid < arr.Length ? mid : int.MaxValue;
                // 对于每个元素 Ai​，我们都可以唯一确定到第i个元素为止缺失的元素数量为 Ai−i−1
                if (x - mid - 1 >= k)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            int index = left - 1;
            int a = arr[index];
            int p = a - index - 1;
            // 求第k个数的公式
            return k - p + a;

        }


    }
}