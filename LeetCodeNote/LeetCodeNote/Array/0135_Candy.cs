using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 135. 分发糖果
    /// https://leetcode.cn/problems/candy/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>


    public class Solution_135
    {
        public void Run()
        {
            int[] ratings = { 1, 3, 2, 2, 1 };


            int res = Candy_My_0(ratings);
            Console.WriteLine("res:" + res);

        }


        // 我的题解0，根据题意，在每人都有一颗糖基础上，记录了“评价递减区间”最后才做结算
        // 成功！不过这个解法不太清晰
        // 时间复杂度 O(n*n)
        public int Candy_My_0(int[] ratings)
        {
            int n = ratings.Length;
            int[] numArr = new int[n];
            for (int a = 0; a < n; a++)
            {
                numArr[a] = 1;
            }
            int i = 0;
            for (int k = 0; k < n; k++)
            {
                if (k + 1 < n)
                {
                    if (ratings[k + 1] < ratings[k]) // 递减
                    {
                        continue;
                    }
                    // 前面递减范围结算糖果
                    for (int a = k - 1; a >= i; a--)
                    {
                        // 确实小了才多加，这里舍弃了自加而是赋值
                        if (numArr[a] <= numArr[a + 1])
                        {
                            numArr[a] = numArr[a + 1] + 1;
                        }
                    }
                    i = k + 1;
                    if (ratings[k + 1] > ratings[k])
                    {
                        numArr[k + 1] += numArr[k];
                    }
                }
                else
                {
                    // 此时已经遍历到尽头，可能前面还有递减范围还没结算
                    // 递减范围结算糖果
                    for (int a = k - 1; a >= i; a--)
                    {
                        if (numArr[a] <= numArr[a + 1])
                        {
                            numArr[a] = numArr[a + 1] + 1;
                        }
                    }
                }
            }
            return numArr.Sum();

        }

        // method 1 官方题解1
        // 拆分成左、右规则，简单来说，从左算一遍，从右算一遍，取两者最大
        // 时间复杂度 O(n)
        public int Candy_1(int[] ratings)
        {
            int n = ratings.Length;
            int[] left = new int[n];
            for (int i = 0; i < n; i++)
            {
                // 左规则：当ratings[i−1] < ratings[i]时，i号学生的糖果数量将比i−1号孩子的糖果数量多
                if (i > 0 && ratings[i] > ratings[i - 1])
                {
                    left[i] = left[i - 1] + 1;
                }
                else
                {
                    left[i] = 1;
                }
            }
            // 右规则：当 ratings[i] > ratings[i+1] 时，i号学生的糖果数量将比i+1号孩子的糖果数量多。
            // 这里省去了数组，直接用值来算
            int right = 0;
            int res = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (i < n - 1 && ratings[i] > ratings[i + 1])
                {
                    right++;
                }
                else
                {
                    right = 1;
                }
                res += Math.Max(left[i], right);
            }
            return res;

        }

        // method 2 官方题解2
        // 有“我的题解0”影子，不过官方更是设计了递增区间和区间高度（柱状图的高度）
        // 时间复杂度 O(n)
        public int Candy_2(int[] ratings)
        {
            int n = ratings.Length;
            int res = 1; // 因为它是从第二个孩子开始算，所以res为1
            int inc = 1; // 递增区间，因为它是从第二个孩子开始算，而相等或小于都算递增区间里的
            int dec = 0;
            int pre = 1; // 前一个孩子分得的糖果
            for (int i = 1; i < n; i++)
            {
                // 在递增区间（小于和等于）
                if (ratings[i] >= ratings[i - 1])
                {
                    dec = 0;
                    pre = ratings[i] == ratings[i - 1] ? 1 : pre + 1;
                    inc = pre; // 如果遇道相同评价，inc会回到1
                    res += pre;
                }
                // 在递减区间
                else
                {
                    dec++;
                    // 出现了相同高度，说明递增区间和递减部分有接触，可能是恰好接触（两值相等），可能边界融合（递增后立马递减）
                    if (dec == inc) 
                    {
                        dec++;
                    }
                    pre = 1;  // 重置pre为1，为后面可能出现的递增区间做好准备
                    res += dec;
                }
            }
            return res;

        }



    }

}
