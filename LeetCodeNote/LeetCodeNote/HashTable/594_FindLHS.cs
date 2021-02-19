using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 594. 最长和谐子序列
    /// https://leetcode-cn.com/problems/longest-harmonious-subsequence/
    /// </summary>


    public class Solution_594_FindLHS
    {
        // method 0
        public int FindLHS_0(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                bool flag = false;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        count++;
                    }
                    else if (nums[i] == nums[j] + 1)
                    {
                        count++;
                        flag = true;
                    }
                }
                if (flag)
                {
                    res = Math.Max(count, res);
                }
            }
            return res;

        }

        // method 1
        // 用哈希；不会有打乱排序的问题
        public int FindLHS_1(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int res = 0;
            foreach (int num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
            }
            foreach (int key in dic.Keys)
            {
                if (dic.ContainsKey(key + 1))
                {
                    res = Math.Max(dic[key] + dic[key + 1], res);
                }
            }
            return res;

        }

        // method 2
        // method 1的优化
        public int FindLHS_2(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int res = 0;
            foreach (int num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
                if (dic.ContainsKey(num + 1))
                {
                    res = Math.Max(res, dic[num] + dic[num + 1]);
                }
                if (dic.ContainsKey(num - 1))
                {
                    res = Math.Max(res, dic[num] + dic[num - 1]);
                }               
            }
            return res;

        }


    }
}