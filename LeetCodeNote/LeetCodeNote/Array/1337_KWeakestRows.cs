using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1337. 方阵中战斗力最弱的 K 行
    /// https://leetcode-cn.com/problems/the-k-weakest-rows-in-a-matrix/
    /// </summary>

    public class Solution_1337
    {
        // method 0 
        // Linq用法
        public int[] KWeakestRows_0(int[][] mat, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < mat.Length; i++)
            {
                dic.Add(i, mat[i].Sum());
            }
            return dic.OrderBy(a => a.Value).Select(a => a.Key).Take(k).ToArray();

        }

        // method 1
        // 和method 0一个意思，不过这里全是Linq用法
        public int[] KWeakestRows_1(int[][] mat, int k)
        {
            var p = from arr in mat
                let index = System.Array.IndexOf(mat, arr)
                orderby arr.Count(item => item == 1), index
                select index;
            return p.Take(k).ToArray();

        }

    }

}