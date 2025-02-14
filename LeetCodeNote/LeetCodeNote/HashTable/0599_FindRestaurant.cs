using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 599. 两个列表的最小索引总和
    /// https://leetcode-cn.com/problems/minimum-index-sum-of-two-lists/
    /// </summary>

    public class Solution_599_FindRestaurant
    {
        // method 0
        public string[] FindRestaurant_0(string[] list1, string[] list2)
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list1[i] == list2[j])
                    {
                        int key = i + j;
                        if (!dic.ContainsKey(key))
                        {
                            dic.Add(key, new List<string>());
                        }
                        dic[key].Add(list1[i]);
                    }
                }
            }
            int minIndexSum = int.MaxValue;
            foreach (int key in dic.Keys)
            {
                minIndexSum = Math.Min(minIndexSum, key);
            }
            return dic[minIndexSum].ToArray();

        }

        // method 1
        public string[] FindRestaurant_1(string[] list1, string[] list2)
        {
            List<string> res = new List<string>();
            for (int sum = 0; sum < list1.Length + list2.Length - 1; sum++)
            {
                for (int i = 0; i <= sum; i++)
                {
                    if (i < list1.Length && sum - i < list2.Length && list1[i] == list2[sum - i])
                    {
                        res.Add(list1[i]);
                    }
                }
                if (res.Count > 0)
                {
                    break;
                }
            }
            return res.ToArray();

        }

        // method 2
        public string[] FindRestaurant_2(string[] list1, string[] list2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++)
            {
                dic.Add(list1[i], i);
            }
            List<string> res = new List<string>();
            int minSum = int.MaxValue;
            int sum = 0;
            for (int j = 0; j < list2.Length && j <= minSum; j++)
            {
                if (dic.ContainsKey(list2[j]))
                {
                    sum = j + dic[list2[j]];
                    if (sum < minSum)
                    {
                        res.Clear();
                        res.Add(list2[j]);
                        minSum = sum;
                    }
                    else if (sum == minSum)
                    {
                        res.Add(list2[j]);
                    }
                }
            }
            return res.ToArray();

        }


    }



}