using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 189. 旋转数组
    /// https://leetcode-cn.com/problems/rotate-array/
    /// </summary>
    public class Solution_189
    {
        // method 0     
        // 超出时长
        public void Rotate_0(int[] nums, int k)
        {
            int temp;
            int pre;
            for (int i = 0; i < k; i++)
            {
                pre = nums[nums.Length - 1];
                for (int j = 0; j < nums.Length; j++)
                {
                    temp = nums[j];
                    nums[j] = pre;
                    pre = temp;
                }
            }
        }

        // method 1     
        // 空间复杂度不符题意
        public void Rotate_1(int[] nums, int k)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int index = (i + k) % nums.Length;
                a[index] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = a[i];
            }
        }

        // method 2      
        public void Rotate_2(int[] nums, int k)
        {
            k %= nums.Length;
            int count = 0;
            int curIndex;
            int nextIndex;
            int prev;
            int temp;
            for (int begin = 0; count < nums.Length; begin++)
            {
                curIndex = begin;
                prev = nums[curIndex];
                do
                {
                    // swap( nums[nextIndex], prev )
                    nextIndex = (curIndex + k) % nums.Length;
                    temp = nums[nextIndex];
                    nums[nextIndex] = prev;
                    prev = temp;
                    curIndex = nextIndex;
                    count++;
                } while (begin != curIndex);
            }
        }

        // method 3     
        public void Rotate_3(int[] nums, int k)
        {
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        private void reverse(int[] nums, int begin, int end)
        {
            int temp;
            while (begin < end)
            {
                temp = nums[begin];
                nums[begin] = nums[end];
                nums[end] = temp;
                begin++;
                end--;
            }
        }


    }
}
