using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1260. 二维网格迁移
    /// https://leetcode-cn.com/problems/shift-2d-grid/
    /// </summary>

    public class Solution_1260
    {
        // method 3
        // 行列变化是有规律的
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;           
            List<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < m; i++)
            {
                IList<int> newRows = new List<int>();                
                for (int j = 0; j < n; j++)
                {
                    newRows.Add(0);
                }
                res.Add(newRows);
            }
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int newCol = (col + k) % n;
                    int newRow = ((col + k) / n + row) % m;
                    res[newRow][newCol] = grid[row][col];
                }              
            }
            return res;
        }


    }
}