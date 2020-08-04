using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1380. 矩阵中的幸运数
    /// https://leetcode-cn.com/problems/lucky-numbers-in-a-matrix/
    /// </summary>


    public class Solution_1380
    {
        // method 1
        public IList<int> LuckyNumbers_0(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[] rowMin = new int[rows];
            for (int r = 0; r < rowMin.Length; r++)
            {
                rowMin[r] = int.MaxValue;
            }
            int[] colMax = new int[cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int v = matrix[r][c];
                    rowMin[r] = Math.Min(rowMin[r], v);
                    colMax[c] = Math.Max(colMax[c], v);
                }
            }
            List<int> res = new List<int>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int v = matrix[r][c];
                    if (v == rowMin[r] && v == colMax[c])
                    {
                        res.Add(v);
                    }
                }
            }
            return res;

        }






    }


}