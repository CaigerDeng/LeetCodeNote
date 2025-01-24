using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 189. 旋转数组/轮转数组
    /// https://leetcode-cn.com/problems/rotate-array/
    /// </summary>
    public class Solution_189
    {
        public void Run()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };


        }

        // 我的method 0：把算好的数据放新数组里，不过这不是原地算法
        // 官方的method 1
        public void Rotate_My_0(int[] nums, int k)
        {
            int len = nums.Length;
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                int newIndex = (i + k) % len;
                arr[newIndex] = nums[i];
            }

            for (int i = 0; i < len; i++)
            {
                nums[i] = arr[i];
            }

        }


        // 我的method 1：一轮就遍历整个数组，一共有k轮，如果k或nums很大遍历会很耗时    
        // 失败！超出时长
        public void Rotate_My_1(int[] nums, int k)
        {
            int n = nums.Length;
            int pre;
            k = k % n; // 简化k，去掉不必要的循环
            for (int i = 0; i < k; i++)
            {
                pre = nums[n - 1];
                for (int j = 0; j < n; j++)
                {
                    (nums[j], pre) = (pre, nums[j]);
                }
            }
        }

        // method 2_0：官方题解2-环状替换，相对于Rotate_My_0，记下旧值，然后重点是算出要循环几轮
        // 要循环几轮：求nk的最大公约数即可（具体解释见官方，网友也有补充解释，不难理解）
        public void Rotate_2_0(int[] nums, int k)
        {
            int n = nums.Length;
            k %= n; // 简化k，去掉不必要的循环
            int count = (int)BigInteger.GreatestCommonDivisor(n, k);
            int curIndex;
            int nextIndex;

            int prev;
            for (int i = 0; i < count; i++)
            {
                prev = nums[i];
                curIndex = i;
                do
                {
                    nextIndex = (curIndex + k) % n;
                    (nums[nextIndex], prev) = (prev, nums[nextIndex]);
                    curIndex = nextIndex;
                } while (i != curIndex);
            }
        }


        // method 2_1：官方题解2-环状替换，相对于Rotate_My_0，记下旧值，然后重点是算出要循环几轮
        // 要循环几轮：不知道要循环几轮，但可以保证已访问元素数量不超出边界
        public void Rotate_2(int[] nums, int k)
        {
            int n = nums.Length;
            k %= n; // 简化k，去掉不必要的循环
            int count = 0;
            int curIndex;
            int nextIndex;
            int prev;
            for (int i = 0; count < n; i++)
            {
                prev = nums[i];
                curIndex = i;
                do
                {
                    nextIndex = (curIndex + k) % n;
                    (nums[nextIndex], prev) = (prev, nums[nextIndex]);
                    curIndex = nextIndex;
                    count++;
                } while (i != curIndex);
            }
        }

        // method 3：官方题解3，数组翻转
        // 仍以“数组[1, 2, 3, 4, 5, 6, 7]，n=7，k=3”为例，
        // k=3就意味着数组后3个数要挤到前面去，其余4个数依次往后挤。
        // 先看它的轮转结果为[5, 6, 7, 1, 2, 3, 4]，而原数组的翻转结果为[7, 6, 5, 4, 3, 2, 1]，
        // 显然翻转结果和轮转结果相比已经十分接近。
        // 那接下来就是对翻转结果的进一步修正，具体为对前3个数再翻转和后4个数再翻转。
        public void Rotate_3(int[] nums, int k)
        {
            int n = nums.Length;
            k %= n;
            System.Array.Reverse(nums); // 翻转整个数组
            System.Array.Reverse(nums, 0, k);
            System.Array.Reverse(nums, k, n - k);
        }


    }
}
