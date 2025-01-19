using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 238. 除自身以外数组的乘积
    /// https://leetcode.cn/problems/product-of-array-except-self/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_238
    {
        public void Run()
        {




        }

        // 我的题解0
        // 没写出来！如果允许使用除法的话，我只要把所有元素的乘积除以那个元素就完事了，但不让用！剩下的我只想出了O(n*n)复杂度，也不合题意。
        public int[] ProductExceptSelf_My_0(int[] nums)
        {
            int[] res = new int[nums.Length];
            return res;

        }

        // method 1 官方题解一
        // 左右乘积列表，某个元素的结果就是它左边总乘积和右边总乘积的乘积。
        // 这里的空间复杂度是O(n)
        public int[] ProductExceptSelf_1(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];

            int[] leftArr = new int[n];
            leftArr[0] = 1; // 左乘积第一个元素肯定为1
            for (int i = 1; i < n; i++) // 不用算到最后一个元素，因为题目要求
            {
                leftArr[i] = leftArr[i - 1] * nums[i - 1];
            }

            int[] rightArr = new int[n];
            rightArr[^1] = 1; // 右乘积最后一个元素肯定为1
            for (int i = n - 2; i >= 0; i--)
            {
                rightArr[i] = rightArr[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                res[i] = leftArr[i] * rightArr[i];
            }
            return res;

        }

        // method 2 官方题解二
        // 是在method 1基础上优化出的空间复杂度O(1)
        public int[] ProductExceptSelf_2(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            // 先把res当做左乘积数组用
            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }

            // 右乘积数组融入到res中
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i]; // 这是下一次的右乘积
            }

            return res;

        }






    }



}
