using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1475. 商品折扣后的最终价格
    /// https://leetcode-cn.com/problems/final-prices-with-a-special-discount-in-a-shop/
    /// </summary>


    public class Solution_1475
    {

        // method 0
        // 暴力
        public int[] FinalPrices_0(int[] prices)
        {
            int[] res = new int[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                int dis = 0;
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] <= prices[i])
                    {
                        dis = prices[j];
                        break;
                    }

                }
                res[i] = prices[i] - dis;
            }
            return res;

        }

        // method 1
        // 单调（递增）栈
        // 参考 https://leetcode-cn.com/problems/final-prices-with-a-special-discount-in-a-shop/solution/dan-diao-zhan-zui-quan-mian-xiang-jie-bao-ni-dong-/
        public int[] FinalPrices_1(int[] prices)
        {
            int[] res = new int[prices.Length];
            // stack存的是数组索引
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < prices.Length; i++)
            {
                // stack.Peek获取栈顶值但不删
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                {
                    int index = stack.Pop();
                    res[index] = prices[index] - prices[i];
                }
                stack.Push(i);                
            }
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                res[index] = prices[index];
            }
            return res;

        }



    }
}