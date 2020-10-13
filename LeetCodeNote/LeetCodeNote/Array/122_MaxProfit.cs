namespace LeetCodeNote.Array
{
    /// <summary>
    /// 122. 买卖股票的最佳时机 II
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/
    /// </summary>


    public class Solution_122
    {
        // method 0
        public int MaxProfit_0(int[] prices)
        {
            return Calculate(prices, 0);

        }

        private int Calculate(int[] prices, int s)
        {
            if (s >= prices.Length)
            {
                return 0;               
            }
            int max = 0;
            for (int start = s; start < prices.Length; start++)
            {
                int maxProfit = 0;
                for (int i = start + 1; i < prices.Length; i++)
                {
                    if (prices[start] < prices[i])
                    {
                        int profit = Calculate(prices, i + 1) + prices[i] - prices[start];
                        if (profit > maxProfit)
                        {
                            maxProfit = profit;
                        }
                    }
                }
                if (maxProfit > max)
                {
                    max = maxProfit;
                }
            }
            return max;

        }

        // method 1
        // 来自他人的题解，我觉得解释更具体
        // https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/solution/best-time-to-buy-and-sell-stock-ii-zhuan-hua-fa-ji/
        public int MaxProfit_1(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int profit = prices[i] - prices[i - 1];
                if (profit > 0)
                {
                    maxProfit += profit;
                }
            }
            return maxProfit;

        }

    }

}