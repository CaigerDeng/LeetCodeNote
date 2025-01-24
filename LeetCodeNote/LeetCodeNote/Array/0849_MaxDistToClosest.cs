using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 849. 到最近的人的最大距离
    /// https://leetcode-cn.com/problems/maximize-distance-to-closest-person/
    /// </summary>


    public class Solution_849
    {
        // method 0
        public int MaxDistToClosest_0(int[] seats)
        {
            int N = seats.Length;
            int[] left = new int[N];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = N;
            }
            int[] right = new int[N];
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = N;
            }
            for (int i = 0; i < N; i++)
            {
                if (seats[i] == 1)
                {
                    left[i] = 0;
                }
                else if (i > 0)
                {
                    left[i] = left[i - 1] + 1;
                }
            }
            for (int i = N - 1; i >= 0; i--)
            {
                if (seats[i] == 1)
                {
                    right[i] = 0;
                }
                else if (i < N - 1)
                {
                    right[i] = right[i + 1] + 1;
                }
            }
            int res = 0;
            for (int i = 0; i < N; i++)
            {
                if (seats[i] == 0)
                {
                    // Math.Min(left[i], right[i]) 考虑离得最近的人
                    res = Math.Max(res, Math.Min(left[i], right[i]));
                }
            }
            return res;
        }

        // method 1
        public int MaxDistToClosest_1(int[] seats)
        {
            int N = seats.Length;
            int prev = -1;
            int future = 0;
            int res = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    prev = i;
                }
                else
                {
                    while (future < N && seats[future] == 0 || future < i)
                    {
                        future++;
                    }
                    int left = prev == -1 ? N : i - prev;
                    int right = future == N ? N : future - i;
                    res = Math.Max(res, Math.Min(left, right));
                }
            }
            return res;
        }

        // method 2
        public int MaxDistToClosest_2(int[] seats)
        {
            int N = seats.Length;
            int K = 0;
            int res = 0;
            for (int i = 0; i < N; i++)
            {
                if (seats[i] == 1)
                {
                    K = 0;
                }
                else
                {
                    K++;
                    // 此情况不适用于一侧无人的情况，因为这里还除以了2
                    res = Math.Max(res, (K + 1) / 2);
                }
            }
            // 以下两个for循环处理一侧无人的情况
            for (int i = 0; i < N; i++)
            {
                if (seats[i] == 1)
                {
                    res = Math.Max(res, i);
                    break;
                }
            }
            for (int i = N - 1; i >= 0; i--)
            {
                if (seats[i] == 1)
                {
                    res = Math.Max(res, N - 1 - i);
                    break;
                }
            }
            return res;
        }











    }



}