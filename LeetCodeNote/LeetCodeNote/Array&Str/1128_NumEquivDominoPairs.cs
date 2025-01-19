using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1128. 等价多米诺骨牌对的数量
    /// https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/
    /// （什么是多米诺骨牌：http://zujuan.xkw.com/23q2761563.html）
    /// 题解来自：https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/solution/deng-jie-duo-mi-nuo-gu-pai-by-coldme-2/
    /// </summary>

    public class Solution_1128
    {
        // method 0
        // 此题解不能采用，因为dominoes数量过多时会超时
        public int NumEquivDominoPairs_0(int[][] dominoes)
        {
            int count = 0;
            for (int i = 0; i < dominoes.Length; i++)
            {
                for (int j = i + 1; j < dominoes.Length; j++)
                {
                    if (dominoes[i][0] == dominoes[j][0] && dominoes[i][1] == dominoes[j][1])
                    {
                        count++;
                    }
                    else if (dominoes[i][0] == dominoes[j][1] && dominoes[i][1] == dominoes[j][0])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // method 1
        // 优化method 0，使用等价牌的思想（涉及“排列组合”中的：组合），剔除重复

        public int NumEquivDominoPairs_1(int[][] dominoes)
        {
            // 转成list是为了用remove方法
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < dominoes.Length; i++)
            {
                list.Add(dominoes[i].ToList());
            }
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int num = 0;
                if (i >= list.Count)
                {
                    break;
                }
                for (int j = list.Count - 1; j > i; j--)
                {
                    if (list[i][0] == list[j][0] && list[i][1] == list[j][1])
                    {
                        num++;
                        list.RemoveAt(j);
                    }
                    else if (list[i][0] == list[j][1] && list[i][1] == list[j][0])
                    {
                        num++;
                        list.RemoveAt(j);
                    }
                }
                count += (num + 1) * num / 2; // 组合公式
            }
            return count;
        }

        // method 2
        // 优化method 1，选择另一种数据结构
        public int NumEquivDominoPairs_2(int[][] dominoes)
        {
            int count = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < dominoes.Length; i++)
            {
                int num1 = dominoes[i][0];
                int num2 = dominoes[i][1];
                int k = num1 < num2 ? num1 * 10 + num2 : num2 * 10 + num1;
                if (!dic.ContainsKey(k))
                {
                    dic[k] = 0;
                }
                dic[k]++;
            }
            foreach (int v in dic.Values)
            {
                count += v * (v - 1) / 2; // 组合公式
            }
            return count;
        }








    }
}