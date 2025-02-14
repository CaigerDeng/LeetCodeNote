using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 961. 重复 N 次的元素
    /// https://leetcode-cn.com/problems/n-repeated-element-in-size-2n-array/
    /// </summary>

    public class Solution_961_RepeatedNTimes
    {
        // method 0
        public int RepeatedNTimes_0(int[] A)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int x in A)
            {
                if (!dic.ContainsKey(x))
                {
                    dic.Add(x, 0);
                }
                dic[x]++;
            }
            foreach (KeyValuePair<int, int> pair in dic)
            {
                if (pair.Value > 1)
                {
                    return pair.Key;
                }
            }
            return 0;

        }

        // method 1
        public int RepeatedNTimes_1(int[] A)
        {
            for (int k = 1; k <= 3; k++)
            {
                for (int i = 0; i < A.Length - k; i++)
                {
                    if (A[i] == A[i + k])
                    {
                        return A[i];
                    }
                }
            }
            return 0;

        }

    }



}



