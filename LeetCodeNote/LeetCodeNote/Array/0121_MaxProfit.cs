using System.Runtime.InteropServices;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 121. 买卖股票的最佳时机
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>

    public class Solution_121
    {
        // 我的method 0：直接按题意写，没有包含什么特别算法
        // 同时是官方题解一
        // 会超时！
        public int MaxProfit_My_0(int[] prices)
        {
            int len = prices.Length;
            int maxProfit = 0;
            int prevSale;
            for (int i = 0; i <= len - 2; i++)
            {
                prevSale = 0;
                for (int j = i + 1; j <= len - 1; j++)
                {
                    // 后续售价的优化
                    if (prices[j] < prices[i] || prices[j] < prevSale)
                    {
                        continue;
                    }
                    int p = prices[j] - prices[i];
                    if (p > maxProfit)
                    {
                        maxProfit = p;
                        prevSale = prices[j];
                    }
                }
            }
            return maxProfit;

        }


        // method 1：只用一次遍历，记录售卖日之前的史低价来算历史最大利润
        // 此处官方对何时取最低点解释有误（我上面也有补充），请看评论区精选第一条解释 https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/solution/121-mai-mai-gu-piao-de-zui-jia-shi-ji-by-leetcode-/276129
        public int MaxProfit_1(int[] prices)
        {
            int minBuy = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minBuy)
                {
                    minBuy = prices[i];
                }
                // 这里的elseif保证了今天只有两种选择，要么算至今的史低价，要么算最大利润
                // 比如以[6, 100, 1, 2, 4]为例，显然6不是总史低价，但选6可以卖出最大利润
                else if (prices[i] - minBuy > maxProfit)
                {
                    maxProfit = prices[i] - minBuy;
                }
            }
            return maxProfit;

        }




    }


}