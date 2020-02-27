using System;
using System.Collections.Generic;
using System.Collections;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 88. 合并两个有序数组
    /// https://leetcode-cn.com/problems/merge-sorted-array/
    /// </summary>
    public class Solution_88
    {
        // method 0       
        public void Merge_0(int[] nums1, int m, int[] nums2, int n)
        {
            // nums2.CopyTo(nums1, m); 也可以
            System.Array.Copy(nums2, 0, nums1, m, n);
            System.Array.Sort(nums1);
        }

        // method 1      
        public void Merge_1(int[] nums1, int m, int[] nums2, int n)
        {
            // 考虑过新建一个不拷贝num1的结果数组res，但res就需要n + m的空间，而num1Copy数组空间只需要m，所以还是选择num1Copy
            int[] num1Copy = new int[m];
            // nums1.CopyTo(num1Copy, 0) 不能用，因为nums1可能会很长，num1Copy就会越界
            System.Array.Copy(nums1, 0, num1Copy, 0, m);
            int p = 0;
            int p1 = 0;
            int p2 = 0;
            while (p1 < m && p2 < n)
            {
                nums1[p++] = (num1Copy[p1] < nums2[p2]) ? num1Copy[p1++] : nums2[p2++];
            }
            if (p1 < m)
            {
                System.Array.Copy(num1Copy, p1, nums1, p1 + p2, m + n - p1 - p2);
            }
            if (p2 < n)
            {
                System.Array.Copy(nums2, p2, nums1, p1 + p2, m + n - p1 - p2);
            }
        }

        // method 2       
        public void Merge_2(int[] nums1, int m, int[] nums2, int n)
        {
            int p = m + n - 1;
            int p1 = m - 1;
            int p2 = n - 1;
            while (p1 >= 0 && p2 >= 0)
            {
                nums1[p--] = (nums1[p1] < nums2[p2]) ? nums2[p2--] : nums1[p1--];
            }

            //针对这种情况：nums1 = [6, ...]，m = 1, nums2 = [2, 3]，n = 2
            System.Array.Copy(nums2, 0, nums1, 0, p2 + 1);
        }



    }
}