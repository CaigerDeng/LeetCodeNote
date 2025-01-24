using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 977. 有序数组的平方
    /// https://leetcode-cn.com/problems/squares-of-a-sorted-array/
    /// </summary>

    public class Solution_977
    {
        // method 0
        // 直接排序
        public int[] SortedSquares_0(int[] A)
        {
            int N = A.Length;
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = A[i] * A[i];
            }
            System.Array.Sort(res);
            return res;
        }

        // method 1
        // 双指针
        public int[] SortedSquares_1(int[] A)
        {
            int N = A.Length;
            int j = 0;
            while (j < N && A[j] < 0)
            {
                j++;
            }
            int i = j - 1;
            int[] res = new int[N];
            int t = 0;
            while (i >= 0 && j < N)
            {
                if (A[i] * A[i] < A[j] * A[j])
                {
                    res[t++] = A[i] * A[i];
                    i--;
                }
                else
                {
                    res[t++] = A[j] * A[j];
                    j++;
                }
            }
            // 当j走到尽头
            while (i >= 0)
            {
                res[t++] = A[i] * A[i];
                i--;
            }
            // 当i走到尽头
            while (j < N)
            {
                res[t++] = A[j] * A[j];
                j++;
            }
            return res;
        }



    }


}