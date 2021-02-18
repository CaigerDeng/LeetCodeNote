using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    public class Solution_575_DistributeCandies
    {
        /// <summary>
        /// 575. 分糖果
        /// https://leetcode-cn.com/problems/distribute-candies/
        /// </summary>

        private int max_kind = 0;

        // method 0
        public int DistributeCandies_0(int[] candyType)
        {
            Permute(candyType, 0);
            return max_kind;

        }

        private void Permute(int[] nums, int index)
        {
            if (index == nums.Length - 1)
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < nums.Length / 2; i++)
                {
                    set.Add(nums[i]);
                }
                max_kind = Math.Max(max_kind, set.Count);
            }
            for (int i = index; i < nums.Length; i++)
            {
                Swap(nums, i, index);
                Permute(nums, index + 1);
                Swap(nums, i, index);
            }

        }

        private void Swap(int[] nums, int xIndex, int yIndex)
        {
            int temp = nums[xIndex];
            nums[xIndex] = nums[yIndex];
            nums[yIndex] = temp;

        }

        // method 1
        public int DistributeCandies_1(int[] candyType)
        {
            int count = 0;
            for (int i = 0; i < candyType.Length && count < candyType.Length / 2; i++)
            {
                if (candyType[i] != int.MinValue)
                {
                    count++;
                    for (int j = i + 1; j < candyType.Length; j++)
                    {
                        if (candyType[j] == candyType[i])
                        {
                            candyType[j] = int.MinValue;
                        }
                    }
                }
            }
            return count;

        }

        // method 2
        public int DistributeCandies_2(int[] candyType)
        {
            System.Array.Sort(candyType);
            int count = 1;
            for (int i = 1; i < candyType.Length && count < candyType.Length / 2; i++)
            {
                if (candyType[i] > candyType[i - 1])
                {
                    count++;
                }
            }
            return count;

        }

        // method 3
        public int DistributeCandies_3(int[] candyType)
        {
            HashSet<int> hs = new HashSet<int>();
            foreach (int i in candyType)
            {
                hs.Add(i);
            }
            return Math.Min(candyType.Length / 2, hs.Count);

        }


    }
}