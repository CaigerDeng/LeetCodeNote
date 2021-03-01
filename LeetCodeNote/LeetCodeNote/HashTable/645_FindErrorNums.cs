using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 645. 错误的集合
    /// https://leetcode-cn.com/problems/set-mismatch/
    /// </summary>

    public class Solution_645_FindErrorNums
    {
        // method 0
        public int[] FindErrorNums_0(int[] nums)
        {
            int dup = -1;
            int missing = -1;
            for (int i = 1; i <= nums.Length; i++) // 值从1到n
            {
                int count = 0;
                for (int j = 0; j < nums.Length; j++) // 单纯的for循环
                {
                    if (nums[j] == i)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    dup = i;
                }
                else if (count == 0)
                {
                    missing = i;
                }
            }
            return new[] { dup, missing };

        }

        // method 1
        // 对 method 0 的优化
        public int[] FindErrorNums_1(int[] nums)
        {
            int dup = -1;
            int missing = -1;
            for (int i = 1; i <= nums.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == i)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    dup = i;
                }
                else if (count == 0)
                {
                    missing = i;
                }
                if (dup > 0 && missing > 0)
                {
                    break;
                }
            }
            return new[] { dup, missing };

        }

        // method 2
        public int[] FindErrorNums_2(int[] nums)
        {
            System.Array.Sort(nums);
            int dup = -1;
            // missing从1开始，因为还有这种情况{2, 2}
            int missing = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    dup = nums[i];
                }
                else if (nums[i] > nums[i - 1] + 1)
                {
                    missing = nums[i - 1] + 1;
                }
            }
            missing = (nums[nums.Length - 1] != nums.Length ? nums.Length : missing);
            return new[] { dup, missing };

        }

        // method 3
        public int[] FindErrorNums_3(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int dup = -1;
            int missing = -1;
            foreach (int n in nums)
            {
                if (!dic.ContainsKey(n))
                {
                    dic.Add(n, 0);
                }
                dic[n]++;
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                if (dic.ContainsKey(i))
                {
                    if (dic[i] == 2)
                    {
                        dup = i;
                    }
                }
                else
                {
                    missing = i;
                }
            }
            return new[] { dup, missing };

        }

        // method 4
        // 只是method 3里的词典换成数组
        public int[] FindErrorNums_4(int[] nums)
        {
            int[] arr = new int[nums.Length + 1];
            int dup = -1;
            int missing = -1;
            foreach (int n in nums)
            {
                arr[n]++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    missing = i;
                }
                else if (arr[i] == 2)
                {
                    dup = i;
                }
            }
            return new[] { dup, missing };

        }

        // method 5
        public int[] FindErrorNums_5(int[] nums)
        {
            int dup = -1;
            int missing = -1;
            foreach (int n in nums)
            {
                if (nums[Math.Abs(n) - 1] < 0)
                {
                    dup = Math.Abs(n);
                }
                else
                {
                    // 因为把结果变为负值，所以取索引时需要绝对值
                    nums[Math.Abs(n) - 1] *= -1;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    missing = i + 1;
                }
            }
            return new[] { dup, missing };

        }

        // method 6
        public int[] FindErrorNums_6(int[] nums)
        {
            // 假设nums数组为A，正确的1到n数组为B
            int xor = 0;
            int xor0 = 0;
            int xor1 = 0;
            // 通过对A和B的异或，得到 dup^missing
            foreach (int n in nums)
            {
                xor ^= n;
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                xor ^= i;
            }
            // 得到二进制最右边的1
            int rightmostbit = xor & ~(xor - 1);
            foreach (int n in nums)
            {
                if ((n & rightmostbit) != 0)
                {
                    xor1 ^= n;
                }
                else
                {
                    xor0 ^= n;
                }
            }
            // 按rightmostbit再把对A和B分堆，有一堆肯定会把3个重复数（即A中的俩重复数+B中重复数对应数）分在一起，这3个数异或后只剩下一个重复数
            for (int i = 1; i <= nums.Length; i++)
            {
                if ((i & rightmostbit) != 0)
                {
                    xor1 ^= i;
                }
                else
                {
                    xor0 ^= i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == xor0)
                {
                    return new[] { xor0, xor1 };
                }
            }
            return new[] { xor1, xor0 };

        }





    }
}