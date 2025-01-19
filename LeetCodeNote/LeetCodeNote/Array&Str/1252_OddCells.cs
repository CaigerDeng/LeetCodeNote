using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1252. 奇数值单元格的数目
    /// https://leetcode-cn.com/problems/cells-with-odd-values-in-a-matrix/
    /// 题解来自：https://leetcode-cn.com/problems/cells-with-odd-values-in-a-matrix/solution/ti-jie-1252-qi-shu-zhi-dan-yuan-ge-de-shu-mu-by-ze/
    /// </summary>

    public class Solution_1252
    {
        // method 0
        // 直译法
        public int OddCells_0(int n, int m, int[][] indices)
        {
            int[,] matrix = new int[n, m];
            for (int i = 0; i < indices.Length; i++)
            {
                int x = indices[i][0];
                int y = indices[i][1];
                // rank 维数,这里维数为2
                int row = matrix.GetLength(0);
                int col = matrix.GetLength(1);
                for (int j = 0; j < col; j++)
                {
                    matrix[x, j] += 1;
                }
                for (int j = 0; j < row; j++)
                {
                    matrix[j, y] += 1;
                }
            }
            int num = 0;
            foreach (var val in matrix)
            {
                if (val % 2 != 0)
                {
                    num++;
                }
            }
            return num;
        }


        // method 1
        // 针对method 0，优化了matrix的数据结构
        public int OddCells_1(int n, int m, int[][] indices)
        {
            int[] rows = new int[n];
            int[] cols = new int[m];
            for (int i = 0; i < indices.Length; i++)
            {
                int x = indices[i][0];
                int y = indices[i][1];
                rows[x] += 1;
                cols[y] += 1;
            }
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = rows[i] + cols[j];
                    if (val % 2 != 0)
                    {
                        num++;
                    }
                }
            }
            return num;
        }


        // method 2
        // 针对method 1，优化了后面计数算法
        public int OddCells_2(int n, int m, int[][] indices)
        {
            int[] rows = new int[n];
            int[] cols = new int[m];
            for (int i = 0; i < indices.Length; i++)
            {
                int x = indices[i][0];
                int y = indices[i][1];
                rows[x] += 1;
                cols[y] += 1;
            }
            int odd_rows = 0;
            foreach (var x in rows)
            {
                if (x % 2 == 1)
                {
                    odd_rows++;
                }
            }
            int odd_cols = 0;
            foreach (var y in cols)
            {
                if (y % 2 == 1)
                {
                    odd_cols++;
                }
            }
            return odd_rows * (m - odd_cols) + (n - odd_rows) * odd_cols;
        }




    }
}