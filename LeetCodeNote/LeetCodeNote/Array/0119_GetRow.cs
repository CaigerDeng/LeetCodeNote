using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 119. 杨辉三角 II
    /// https://leetcode-cn.com/problems/pascals-triangle-ii/
    /// </summary>


    public class Solution_119
    {
        // method 0
        // 排列组合
        // https://leetcode-cn.com/problems/pascals-triangle-ii/solution/xiang-xi-tong-su-de-si-lu-fen-xi-duo-jie-fa-by--28/
        public IList<int> GetRow(int rowIndex)
        {
            List<int> list = new List<int>();
            int n = rowIndex;
            long pre = 1;
            list.Add(1);
            // 因为list已经添加了一个数，所以k从1开始，
            for (int k = 1; k <= n; k++)
            {
                // 公式 (n-k)/(k+1)! 里的k是从1开始数的，而这里的k是索引（从0开始数），所以k当k-1用
                long cur = pre * (n - k + 1) / k;
                list.Add((int)cur);
                pre = cur;
            }
            return list;

        }


    }
}