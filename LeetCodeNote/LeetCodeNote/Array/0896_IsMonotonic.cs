using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 896. 单调数列
    /// https://leetcode-cn.com/problems/monotonic-array/
    /// </summary>

    public class Solution_896
    {
        // method 0
        public bool IsMonotonic_0(int[] A)
        {
            return Increasing(A) || Decreasing(A);
        }

        public bool Increasing(int[] A)
        {
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public bool Decreasing(int[] A)
        {
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] < A[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


        // method 1
        public bool IsMonotonic_1(int[] A)
        {
            int store = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                int c = A[i].CompareTo(A[i + 1]);
                if (c != 0)
                {
                    if (c != store && store != 0)
                    {
                        return false;
                    }
                    store = c;
                }
            }
            return true;
        }





    }






}