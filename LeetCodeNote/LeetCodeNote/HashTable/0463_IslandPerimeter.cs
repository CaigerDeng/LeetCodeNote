namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 463. 岛屿的周长
    /// https://leetcode-cn.com/problems/island-perimeter/
    /// </summary>

    public class Solution_463_IslandPerimeter
    {
        private static int[] dx = new[] { 0, 1, 0, -1 };
        private static int[] dy = new[] { 1, 0, -1, 0 };

        // method 0
        public int IslandPerimeter_0(int[][] grid)
        {
            int res = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            int tx = r + dx[i];
                            int ty = c + dy[i];
                            if (tx < 0 || tx >= rows || ty < 0 || ty >= cols || grid[tx][ty] == 0)
                            {
                                res++;
                            }
                        }
                    }
                }
            }
            return res;

        }

        // method 1
        // 其实是把method 0最里面的for循环做成了DFS
        public int IslandPerimeter_1(int[][] grid)
        {
            int res = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        res += DFS(r, c, grid, rows, cols);
                    }
                }
            }
            return res;

        }

        private int DFS(int r, int c, int[][] grid, int rows, int cols)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == 0)
            {
                return 1;
            }
            if (grid[r][c] == 2)
            {
                return 0;
            }
            grid[r][c] = 2;
            int res = 0;
            for (int i = 0; i < 4; i++)
            {
                int tx = r + dx[i];
                int ty = c + dy[i];
                res += DFS(tx, ty, grid, rows, cols);
            }
            return res;

        }


    }

}