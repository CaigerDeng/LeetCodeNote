using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 1640. 能否连接形成数组
    /// https://leetcode-cn.com/problems/check-array-formation-through-concatenation/
    /// </summary>


    public class Solution_1640_CanFormArray
    {
        // method 0
        public bool CanFormArray_0(int[] arr, int[][] pieces)
        {
            Dictionary<int, int[]> dic = new Dictionary<int, int[]>();
            foreach (int[] p in pieces)
            {
                dic.Add(p[0], p);
            }
            int i = 0;
            while (i < arr.Length)
            {
                if (dic.ContainsKey(arr[i]))
                {
                    int[] piece = dic[arr[i]];
                    foreach (int p in piece)
                    {
                        if (p == arr[i])
                        {
                            i++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

    }
}