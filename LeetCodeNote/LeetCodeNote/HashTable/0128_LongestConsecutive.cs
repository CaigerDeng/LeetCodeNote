using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 128. 最长连续序列
    /// https://leetcode.cn/problems/longest-consecutive-sequence/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_128
    {

        public void Run()
        {
            //int[] nums = new int[] { 100, 4, 200, 1, 3, 2 }; // res:4

            //int[] nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }; // res:9

            //int[] nums = new int[] { 1, 0, 1, 2 }; // res:3

            int[] nums = new int[] { 0, 1, 2, 4, 8, 5, 6, 7, 9, 3, 55, 88, 77, 99, 999999999 }; // res:


            int res = LongestConsecutive_My_0(nums);
            Console.WriteLine("res:{0}", res);


        }

        // (2025/2/17) method My 0-我的题解0
        // 先找出数组中最小值和最大值，确定范围；在这个范围用词典记下数组中存在的值。不过这个范围可能拉得太大。
        // 失败！超出时限！
        // 时间复杂度：O(?)，空间复杂度：O(N)
        public int LongestConsecutive_My_0(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            HashSet<int> hashSet = new HashSet<int>();
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums)
            {
                if (num < min)
                {
                    min = num;
                }
                if (num > max)
                {
                    max = num;
                }
                hashSet.Add(num);
            }
            // 尽力缩小dic的大小
            bool hasGap = false;
            for (int i = min; i <= max; i++)
            {
                if (hashSet.Contains(i))
                {
                    dic[i] = true;
                    hasGap = false;
                }
                else
                {
                    if (!hasGap)
                    {
                        dic.Add(i, false);
                        hasGap = true;
                    }
                }
            }
            bool lastV = false;
            int maxLen = 1;
            int count = 1;
            foreach (KeyValuePair<int, bool> kv in dic)
            {
                if (kv.Value == lastV && kv.Value == true)
                {
                    count++;
                    if (count > maxLen)
                    {
                        maxLen = count;
                    }
                }
                else
                {
                    count = 1;
                }
                lastV = kv.Value;
            }
            return maxLen;

        }

        // method 1-官方题解1
        // 从一个纯粹的起点开始找连续序列。
        // 时间复杂度：O(?)，空间复杂度：O(?)
        public int LongestConsecutive_1(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();
            // 去重
            foreach (int num in nums)
            {
                hashSet.Add(num);
            }

            int maxLen = 0;
            foreach (int num in hashSet)
            {
                // 起点要纯粹，不能有前驱数
                if (!hashSet.Contains(num - 1))
                {
                    int currNum = num;
                    int currLen = 1;
                    // 查找连续序列
                    while (hashSet.Contains(currNum + 1))
                    {
                        currNum++;
                        currLen++;
                    }
                    maxLen = Math.Max(maxLen, currLen);
                }
            }
            return maxLen;

        }





    }

}
