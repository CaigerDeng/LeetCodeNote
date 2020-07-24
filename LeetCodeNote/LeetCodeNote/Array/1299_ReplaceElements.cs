using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1299. 将每个元素替换为右侧最大元素
    /// https://leetcode-cn.com/problems/replace-elements-with-greatest-element-on-right-side/
    /// </summary>

    public class Solution_1299
    {
        // method 0        
        public int[] ReplaceElements(int[] arr)
        {
            int n = arr.Length;
            int[] res = new int[n];
            res[n - 1] = -1;
            // 不是顺序遍历，而是逆序遍历，这样会更省时间
            for (int i = n - 2; i >= 0; i--)
            {
                res[i] = Math.Max(res[i + 1], arr[i + 1]);
            }
            return res;

        }


    }

}