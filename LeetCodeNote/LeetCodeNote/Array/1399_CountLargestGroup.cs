using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1399. 统计最大组的数目
    /// https://leetcode-cn.com/problems/count-largest-group/
    /// </summary>


    public class Solution_1399
    {

        // method 0
        // 哈希表 key数位和，val符合该数位和的个数
        public int CountLargestGroup_0(int n)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int maxVal = 0;
            for (int i = 1; i <= n; i++)
            {
                int key = 0;
                int temp = i;
                while (temp > 0)
                {
                    // 求数位和
                    key += temp % 10;
                    temp = temp / 10;
                }
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, 0);
                }
                dic[key]++;
                maxVal = Math.Max(maxVal, dic[key]);
            }
            int count = 0;
            foreach (var v in dic.Values)
            {
                if (v == maxVal)
                {
                    count++;
                }
            }
            return count;

        }









    }


}