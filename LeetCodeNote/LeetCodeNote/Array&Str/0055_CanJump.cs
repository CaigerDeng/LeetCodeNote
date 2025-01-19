using System;
using System.Diagnostics;
using System.Reflection;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 55. 跳跃游戏
    /// https://leetcode.cn/problems/jump-game/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>


    public class Solution_55
    {

        public void Run()
        {
            int[] nums_0 = { 1, 0, 1, 0 }; // false
            int[] nums_1 = { 3, 0, 8, 2, 0, 0, 1 }; // true
            int[] nums_2 = { 1, 1, 2, 2, 0, 1, 1 }; // true

            bool res = CanJump_My_0(nums_2);
            Console.WriteLine("res:" + res);

        }


        // 我的题解0
        // 我刚开始看题目，以为会是一个动态规划的问题，但动态规划是用来求最优解的，那这题是一个贪心算法问题？
        // 因为数组中的元素是代表跳跃长度上限，如果上限直接能跳到最后一步的话，那就没必要再考虑减去跳跃长度；
        // 没通过！我写的没有体现往后倒一步，
        // 因为我之前认为如果上限都不能跳到最后一步的话，那再讨论这个元素（上限数字）就没有意义，但事实不是这样的！比如以{ 1, 1, 2, 2, 0, 1, 1 }为例。
        public bool CanJump_My_0(int[] nums)
        {
            int finalIndex = nums.Length - 1;
            if (finalIndex == 0)
            {
                // 如果数组大小为1，这样跳不跳都算成功
                return true;
            }

            if (nums[0] == 0)
            {
                // 如果数组第一个元素为0，这样无法跳跃，肯定失败
                return false;
            }
            return TestNext(nums, 0);

        }

        private bool TestNext(int[] nums, int index)
        {
            int finalIndex = nums.Length - 1;
            int currIndex;
            int len = Math.Min(nums[index], nums.Length);
            for (int i = index; i < len; i++)
            {
                // 直接走，是否能走完
                currIndex = i;
                while (currIndex < finalIndex)
                {
                    int nextIndex = currIndex + nums[currIndex];
                    if (nextIndex >= finalIndex)
                    {
                        return true;
                    }
                    if (nextIndex == currIndex) // 可能跳跃上限为0
                    {
                        break;
                    }
                    currIndex = nextIndex;
                }
            }
            if (index > 0)
            {
                return TestNext(nums, index++);
            }
            return false;

        }

        // method 1-官方题解1
        public bool CanJump_1(int[] nums)
        { 
            int n = nums.Length;
            int rightMost = 0;
            for (int i = 0; i < n; i++)
            {
                // 要保证i要在rightMost范围内，因为这就是i能跳的上限，
                // 比如以[3,2,1,0,0,0,0,0,666,4]为例，中间有一串0，显然从第1个位置最多跳到第4个位置（第1个0的位置），后面0的位置根本就跳不到。
                // 从第2、3个位置同样也只能最多跳到第4个位置。
                if (i <= rightMost)
                {
                    rightMost = Math.Max(rightMost, nums[i] + i);
                    if (rightMost >= n -1)
                    {
                        // 此时已经能跳过最后一个位置
                        return true;
                    }
                }
            }
            return false;

        }




    }

    



}