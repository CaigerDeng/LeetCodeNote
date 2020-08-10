using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1394. 找出数组中的幸运数
    /// https://leetcode-cn.com/problems/find-lucky-integer-in-an-array/
    /// </summary>

    public class Solution_1394
    {
        // method 0
        // 直接遍历
        public int FindLucky_0(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int k = arr[i];
                if (!dic.ContainsKey(k))
                {
                    dic.Add(k, 0);
                }
                dic[k]++;
            }
            int res = -1;
            foreach (KeyValuePair<int, int> item in dic)
            {
                if (item.Key == item.Value)
                {
                    res = Math.Max(item.Key, res);
                }
            }
            return res;

        }







    }



}