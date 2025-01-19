using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1331. 数组序号转换
    /// https://leetcode-cn.com/problems/rank-transform-of-an-array/
    /// </summary>

    public class Solution_1331
    {
        // method 0 
        // mine    
        public int[] ArrayRankTransform_0(int[] arr)
        {
            int[] a = new int[arr.Length];
            arr.CopyTo(a, 0);
            System.Array.Sort(a);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int v = 1;
            for (int i = 0; i < a.Length; i++)
            {
                int k = a[i];
                if (!dic.ContainsKey(k))
                {
                    dic.Add(k, v);
                    v++;
                }
            }
            int[] res = new int[arr.Length];
            for (int i = 0; i < res.Length; i++)
            {
                int k = arr[i];
                res[i] = dic[k];
            }
            return res;
        }

    }
}