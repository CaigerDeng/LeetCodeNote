using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 746. 使用最小花费爬楼梯
    /// https://leetcode-cn.com/problems/min-cost-climbing-stairs/
    /// </summary>


    public class Solution_746
    {
        // method 0
        // 题解来自 https://leetcode-cn.com/problems/min-cost-climbing-stairs/solution/yi-bu-yi-bu-tui-dao-dong-tai-gui-hua-de-duo-chong-/
        // 这里用的是无优化的，理解起来最直白的题解
        public int MinCostClimbingStairs_0(int[] cost)
        {
            int size = cost.Length;
            int[] minCost = new int[size];
            minCost[0] = 0;
            minCost[1] = Math.Min(cost[0], cost[1]);
            for (int i = 2; i < size; i++)
            {
                minCost[i] = Math.Min(minCost[i - 1] + cost[i], minCost[i - 2] + cost[i - 1]);
            }
            return minCost[size - 1];

        }

        // method 1
        // 对 method 0的优化
        public int MinCostClimbingStairs_1(int[] cost)
        {
            int minCost0 = 0;
            int minCost1 = Math.Min(cost[0], cost[1]);
            int minCost = 0;
            for (int i = 2; i < cost.Length; i++)
            {
                minCost = Math.Min(minCost1 + cost[i], minCost0 + cost[i - 1]);
                minCost0 = minCost1;
                minCost1 = minCost;
            }
            return minCost;

        }







    }


}