using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1365. 有多少小于当前数字的数字
    /// https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/
    /// </summary>

    public class Solution_1365
    {
        // method 0 
        // 暴力Linq用法
        public int[] SmallerNumbersThanCurrent_0(int[] nums)
        {
            int[] res = new int[nums.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = nums.Count(item => item < nums[i]);
            }
            return res;

        }

        // method 1
        // 频次数组 + 前缀和
        public int[] SmallerNumbersThanCurrent_1(int[] nums)
        {
            int[] res = new int[nums.Length];
            int[] cnt = new int[101];
            for (int i = 0; i < nums.Length; i++)
            {
                cnt[nums[i]]++;
            }
            // 求前缀和
            for (int i = 1; i <= 100; i++)
            {
                cnt[i] += cnt[i - 1];
            }
            for (int i = 0; i < res.Length; i++)
            {
                int val = nums[i] - 1;
                if (val >= 0)
                {
                    res[i] = cnt[val];
                }                
            }
            return res;

        }

        // method 2
        // 排序
        public int[] SmallerNumbersThanCurrent_2(int[] nums)
        {
            int[] res = new int[nums.Length];
            nums.CopyTo(res, 0);
            System.Array.Sort(res);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < res.Length; i++)
            {
                int k = res[i];
                int v = i;
                if (!dic.ContainsKey(k))
                {
                    dic.Add(k, v);
                }                
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int k = nums[i];
                res[i] = dic[k];
            }
            return res;

        }





    }









}

