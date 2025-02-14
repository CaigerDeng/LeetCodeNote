using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 387. 字符串中的第一个唯一字符
    /// https://leetcode-cn.com/problems/first-unique-character-in-a-string/
    /// </summary>


    public class Solution_350_Intersect
    {
        // method 0
        public int[] Intersect_0(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Intersect_0(nums2, nums1);
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int n in nums1)
            {
                if (!dic.ContainsKey(n))
                {
                    dic.Add(n, 0);
                }
                dic[n]++;
            }
            List<int> list = new List<int>();
            foreach (int n in nums2)
            {
                if (dic.ContainsKey(n))
                {
                    if (dic[n] > 0)
                    {
                        dic[n]--;
                        list.Add(n);
                    }
                }
            }
            return list.ToArray();

        }

        // method 1
        public int[] Intersect_1(int[] nums1, int[] nums2)
        {
            System.Array.Sort(nums1);
            System.Array.Sort(nums2);
            int len1 = nums1.Length;
            int len2 = nums2.Length;
            int[] interArr = new int[Math.Min(len1, len2)];
            int index = 0;
            int index1 = 0;
            int index2 = 0;
            while (index1 < len1 && index2 < len2)
            {
                int n1 = nums1[index1];
                int n2 = nums2[index2];
                if (n1 == n2)
                {
                    interArr[index++] = n1;
                    index1++;
                    index2++;
                }
                else if (n1 < n2)
                {
                    index1++;
                }
                else
                {
                    index2++;
                }
            }
            int[] res = new int[index];
            System.Array.Copy(interArr, res, index);
            return res;

        }


    }




}