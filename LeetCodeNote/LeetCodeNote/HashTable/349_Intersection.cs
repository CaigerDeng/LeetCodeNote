using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 349. 两个数组的交集
    /// https://leetcode-cn.com/problems/intersection-of-two-arrays/
    /// </summary>

    public class Solution_349_Intersection
    {
        // method 0
        // C#现成接口
        public int[] Intersection_0(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();

        }

        // method 1    
        public int[] Intersection_1(int[] nums1, int[] nums2)
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            foreach (int n in nums1)
            {
                hs1.Add(n);
            }
            foreach (int n in nums2)
            {
                hs2.Add(n);
            }
            return GetIntersection(hs1, hs2);

        }

        private int[] GetIntersection(HashSet<int> hs1, HashSet<int> hs2)
        {
            if (hs1.Count > hs2.Count)
            {
                // 保证hs2是总数小的那一方，因为hs2负责判断
                return GetIntersection(hs2, hs1);
            }
            HashSet<int> inter = new HashSet<int>();
            foreach (int n in hs1)
            {
                if (hs2.Contains(n))
                {
                    inter.Add(n);
                }
            }
            return inter.ToArray();

        }

        // method 1    
        public int[] Intersection_2(int[] nums1, int[] nums2)
        {
            System.Array.Sort(nums1);
            System.Array.Sort(nums2);
            int len1 = nums1.Length;
            int len2 = nums2.Length;
            int[] interArr = new int[len1 + len2];
            int index = 0;
            int index1 = 0;
            int index2 = 0;
            while (index1 < len1 && index2 < len2)
            {
                int n1 = nums1[index1];
                int n2 = nums2[index2];
                if (n1 == n2)
                {
                    if (index == 0 || n1 != interArr[index - 1])
                    {
                        interArr[index++] = n1;
                    }
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