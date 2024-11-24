// deng：2023-11-21-看题目有点懵，“找出其中没有出现的最小的正整数”，最小正整数为0，要我找从0开始、然后去掉出现在nums里的数吗？——> 不对！0不是正数，也不是负数！
// deng：我的设计-首先最小正整数预备为1，遍历数组找到最小正整数。最小正整数若不为1则结果取1，否则在最小正整数的基础上自加，每次自加得到的结果都要再遍历数组看是否重复


using System;
using System.Collections.Generic;




namespace LeetCodeNote.Array
{
    /// <summary>
    /// 41. 缺失的第一个整数
    /// https://leetcode.cn/problems/first-missing-positive/
    /// </summary>

    public class Solution_41
    {

        public void Run()
        {
            int[] nums = new[] { 1, 2, 0 };
            int res = FirstMissingPositive_1(nums);
            Print(res);


        }

        public void Print(int res)
        {
            Console.WriteLine(res);

        }

        // method 0
        // 哈希表
        // 说是“哈希表”，其实是取查找便捷之意（不过实际上得到的时间复杂度是O(n)而不是真哈希表的O(1)）。
        // 它破坏了原数组（按题意对空间复杂度要求必然破坏），通过给元素值挂上-1从而加了一层作用——去掉无用区间
        // 最小正整数肯定在[1, n+1]之间，首先左边界1就是最小正整数不用说，右边界的解释——[1,2]的最小正整数为3，[1,999]的最小正整数为2
        // 时间复杂度O(n)，空间复杂度O(1)
        public int FirstMissingPositive_0(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= 0)
                {
                    // 改的值选n+1，是因为n+1不在考虑范围。当然最后的计算结果肯定会有n+1的判断
                    nums[i] = n + 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int num = Math.Abs(nums[i]);
                if (num <= n)
                {
                    nums[num - 1] = Math.Abs(nums[num - 1]) * -1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            // 如果都是负数，结果取n+1
            return n + 1;

        }

        // method 1
        // 置换法
        // 比method 0更好理解，就是把值放在对应位置上（比如1放在第1个位置），整个数组放完后会发现有些位置上的数不符，直接得出该位置的值
        // 时间复杂度O(n)，空间复杂度O(1)
        public int FirstMissingPositive_1(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                // 0、负数、大于n的数不参与变换，因为没必要
                // nums[i] != nums[nums[i] - 1] 防止陷入死循环
                while (nums[i] > 0 && nums[i] <= n && nums[i] != nums[nums[i] - 1])
                {
                    (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return n + 1;

        }


    }

}
