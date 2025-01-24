using System;
using System.Diagnostics;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 122. 买卖股票的最佳时机 II
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/
    /// </summary>


    public class Solution_122
    {

        public void Run()
        {
            int[] prices = { 1, 2, 3, 4, 5 };

            int maxProfit = MaxProfit_My_0(prices);
            Console.WriteLine(maxProfit);

        }


        // 我的题解0，在买卖股票的最佳时机I-method 1基础上修改。
        // 我发现即便允许同天买卖，获得的利润还是一样的（比如：[6, 8, 9]获得利润始终为3）。这样就相当于只要明天价格上涨就今天可以卖，完全不用考虑后面有没有最高价。
        public int MaxProfit_My_0(int[] prices)
        {
            int maxProfit = 0;
            int minBuy = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minBuy)
                {
                    minBuy = prices[i];
                }
                else if (prices[i] - minBuy > 0)
                {
                    maxProfit += prices[i] - minBuy;
                    minBuy = prices[i];
                }
            }
            return maxProfit;



        }



        // method 0-官方题解1
        // 动态规划：即计算所有情况
        public int MaxProfit_0(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 2];
            dp[0, 0] = 0; // 第0天有股票时的利润
            dp[0, 1] = -prices[0]; // 第0天无股票时的利润
            for (int i = 1; i < n; i++)
            {
                // 第i天无股票时的利润：前一天无股票 + 前一天有股票但今天卖了
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                // 第i天有股票时的利润：前一天有股票 + 前一天无股票但今天买了
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }
            // 最后肯定是无股票时的利润比有股票时更多
            return dp[n - 1, 0];

        }

        // method 1-method 0的动态规划上的优化
        public int MaxProfit_1(int[] prices)
        {
            int n = prices.Length;
            int dp0 = 0; // 第0天有股票时的利润
            int dp1 = -prices[0]; // 第0天无股票时的利润
            for (int i = 1; i < n; i++)
            {
                // 第i天无股票时的利润：前一天无股票 + 前一天有股票但今天卖了
                int newDp0 = Math.Max(dp0, dp1 + prices[i]);
                // 第i天有股票时的利润：前一天有股票 + 前一天无股票但今天买了
                int newDp1 = Math.Max(dp1, dp0 - prices[i]);
                dp0 = newDp0;
                dp1 = newDp1;
            }
            // 最后肯定是无股票时的利润比有股票时更多
            return dp0;

        }


        // method 2：贪心
        // 来自他人的题解，我觉得解释比官方更具体（前面我的题解0也解释了）
        // https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/solution/best-time-to-buy-and-sell-stock-ii-zhuan-hua-fa-ji/
        public int MaxProfit_2(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxProfit += Math.Max(prices[i] - prices[i - 1], 0);
            }
            return maxProfit;

        }

    }

}