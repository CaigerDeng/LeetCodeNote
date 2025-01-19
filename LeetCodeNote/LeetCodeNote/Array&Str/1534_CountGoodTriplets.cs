using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1534. 统计好三元组
    /// https://leetcode-cn.com/problems/count-good-triplets/
    /// </summary>


    public class Solution_1534
    {
        // method 0
        // 暴力
        public int CountGoodTriplets_0(int[] arr, int a, int b, int c)
        {
            int len = arr.Length;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    for (int k = j + 1; k < len; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
                        {
                            res++;
                        }
                    }
                }
            }
            return res;

        }

        // method 1
        // 对method 0的优化
        public int CountGoodTriplets_1(int[] arr, int a, int b, int c)
        {
            int len = arr.Length;
            int res = 0;
            int[] sum = new int[1001]; // 从0到1000，自然是1001个数
            for (int j = 0; j < len; j++)
            {
                for (int k = j + 1; k < len; k++)
                {
                    if (Math.Abs(arr[j] - arr[k]) <= b)
                    {
                        int jL = arr[j] - a;
                        int jR = arr[j] + a;
                        int kL = arr[k] - c;
                        int kR = arr[k] + c;
                        // 求交集的左右边界
                        int left = Math.Max(0, Math.Max(jL, kL));
                        int right = Math.Min(1000, Math.Min(jR, kR));
                        if (left <= right)
                        {
                            if (left == 0)
                            {
                                res += sum[right];
                            }
                            else
                            {
                                res += sum[right] - sum[left - 1];
                            }
                        }
                    }
                }
                // 使用前缀和，保证i < j
                for (int k = arr[j]; k <= 1000; k++)
                {
                    sum[k]++;
                }
            }
            return res;

        }









    }

}