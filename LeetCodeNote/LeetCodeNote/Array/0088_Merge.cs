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

        public void Run()
        {
            int[] nums1 = new[] { 4, 5, 6, 0, 0, 0 };
            int m = 3;

            int[] nums2 = new int[] { 1, 2, 3 };
            int n = 3;

            Merge_00(nums1, m, nums2, n);

            Program.PrintArr(nums1);
          


        }

       


        // method 0       
        public void Merge_0(int[] nums1, int m, int[] nums2, int n)
        {
            // nums2.CopyTo(nums1, m); 也可以
            // 时间复杂度：O( (m + n)log(m + n) )。
            // 空间复杂度：O(log(m + n))；如果是指是否要额外存储空间，则为O(1)；如果是指调用栈的深度，则为O(log(m + n))。
            System.Array.Copy(nums2, 0, nums1, m, n);
            System.Array.Sort(nums1);
        }

        // 把method 0 的数组赋值、快排写具体      
        public void Merge_00(int[] nums1, int m, int[] nums2, int n)
        {
            // 按题目要求，没必要判空 
            for (int i = 0; i < n; i++)
            {
                nums1[m + i] = nums2[i];
            }
            QuickSort(nums1);
        }

        private void QuickSort(int[] arr)
        {
            QuickSortDetail(arr, 0, arr.Length - 1);

        }

        private void QuickSortDetail(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int p = QuickSortPart(arr, left, right);
            QuickSortDetail(arr, left, p - 1);
            QuickSortDetail(arr, p + 1, right);

        }

        private int QuickSortPart(int[] arr, int left, int right)
        {
            int num = arr[right];
            int temp = arr[left];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < num)
                {
                    if (arr[j] != num)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                    i++;
                }
            }
            temp = arr[i];
            arr[i] = num;
            arr[right] = temp;
            return i;

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
            // 这里while循环写的很简洁
            while (p1 < m && p2 < n)
            {
                nums1[p++] = (num1Copy[p1] < nums2[p2]) ? num1Copy[p1++] : nums2[p2++];
            }
            // 目标数组的索引从p1 + p2开始数
            if (p1 < m)
            {
                System.Array.Copy(num1Copy, p1, nums1, p1 + p2, m + n - p1 - p2);
            }
            if (p2 < n)
            {
                System.Array.Copy(nums2, p2, nums1, p1 + p2, m + n - p1 - p2);
            }
        }

        // method 2 逆向双指针     
        public void Merge_2_0(int[] nums1, int m, int[] nums2, int n)
        {
            // 逆向双指针
            int p = m + n - 1;
            int p1 = m - 1;
            int p2 = n - 1; 
            while (p1 >= 0 && p2 >= 0)
            {
                nums1[p--] = (nums1[p1] < nums2[p2]) ? nums2[p2--] : nums1[p1--];
            }

            // 针对这种情况：nums1 = [6, ...]，m = 1, nums2 = [2, 3]，n = 2
            // 因为题目中nums1容量肯定比nums2大，所以肯定是把nums2的剩余内容拷贝到nums1去
            System.Array.Copy(nums2, 0, nums1, 0, p2 + 1);
        }

        // method 2 的另一种写法     
        public void Merge_2_1(int[] nums1, int m, int[] nums2, int n)
        {
            // 逆向双指针
            int a = m - 1;
            int b = n - 1;
            int curIndex = m + n - 1;

            while (a >= 0 || b >= 0)
            {
                // nums1已经走完或者m为0
                // 用“m == 0”的判断替换“a == -1”是不行的，因为要考虑到nums1有数但走完的正常情况
                if (a == -1) 
                {
                    nums1[curIndex--] = nums2[b--]; 
                }
                else if (b == -1) 
                {
                    // nums2已经走完或者n为0
                    // 用“n == 0”的判断替换“b == -1”是不行的，因为要考虑到nums2有数但走完的正常情况
                    nums1[curIndex--] = nums1[a--];
                }
                else
                {
                    nums1[curIndex--] = nums1[a] > nums2[b] ? nums1[a--] : nums2[b--];
                }
            }

        }



    }
}