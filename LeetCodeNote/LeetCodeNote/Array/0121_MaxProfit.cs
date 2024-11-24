using System.Runtime.InteropServices;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 121. 买卖股票的最佳时机
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>

    public class Solution_121
    {
        // method 0
        public int MaxProfit_0(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    int profit = prices[j] - prices[i];
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }                
            }
            return maxProfit;

        }

        // method 1
        // 此处官方对何时取最低点解释有误，请看评论区精选第一条解释 https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/solution/121-mai-mai-gu-piao-de-zui-jia-shi-ji-by-leetcode-/276129
        public int MaxProfit_1(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                int v = prices[i];
                if (v < minPrice)
                {
                    minPrice = v;
                }
                else if (v - minPrice > maxProfit)
                {
                    maxProfit = v - minPrice;
                }
            }
            return maxProfit;

        }




    }


}