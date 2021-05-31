using System;

namespace LeetCodeNote.Heap
{
    /// <summary>
    /// 1046. 最后一块石头的重量
    /// https://leetcode-cn.com/problems/last-stone-weight/
    /// </summary>


    public class Solution_1046_LastStoneWeight
    {
        // method 0
        public int LastStoneWeight_0(int[] stones)
        {
            int n = stones.Length;
            if (n == 1)
            {
                return stones[0];
            }
            if (n == 2)
            {
                return Math.Abs(stones[0] - stones[1]);
            }
            System.Array.Sort(stones);
            if (stones[n - 3] == 0)
            {
                return stones[n - 1] - stones[n - 2];
            }
            stones[n - 1] = stones[n - 1] - stones[n - 2];
            stones[n - 2] = 0;
            return LastStoneWeight_0(stones);

        }

        // method 1
        // 使用大顶堆

    }
}