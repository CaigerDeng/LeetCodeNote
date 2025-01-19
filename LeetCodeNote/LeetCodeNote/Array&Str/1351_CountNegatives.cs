namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1351. 统计有序矩阵中的负数
    /// https://leetcode-cn.com/problems/count-negative-numbers-in-a-sorted-matrix/
    /// </summary>

    public class Solution_1351
    {
        // method 0 
        // 暴力
        public int CountNegatives_0(int[][] grid)
        {
            int num = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] < 0)
                    {
                        num++;
                    }
                }
            }
            return num;

        }

        // method 1
        // 二分查找
        public int CountNegatives_1(int[][] grid)
        {
            int num = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int r = 0; r < rows; r++)
            {
                int left = 0;
                int right = cols - 1;
                int pos = -1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (grid[r][mid] < 0)
                    {
                        pos = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                // 如果pos仍为-1，代表这一行都是正数
                if (pos != -1)
                {
                    num += cols - pos;
                }
            }
            return num;

        }

        // method 2 
        // 分治
        public int CountNegatives_2(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            return Solve(0, rows - 1, 0, cols - 1, grid);

        }

        private int Solve(int leftRow, int rightRow, int leftCol, int rightCol, int[][] grid)
        {
            if (leftRow > rightRow)
            {
                return 0;
            }
            int midRow = leftRow + (rightRow - leftRow) / 2;
            int pos = -1;
            for (int c = leftCol; c <= rightCol; c++)
            {
                if (grid[midRow][c] < 0)
                {
                    pos = c;
                    break;
                }
            }
            int res = 0;
            int cols = grid[0].Length;
            if (pos != -1)
            {
                res += cols - pos;
                res += Solve(leftRow, midRow - 1, pos, rightCol, grid);
                res += Solve(midRow + 1, rightRow, leftCol, pos, grid);
            }
            else
            {
                // 如果pos仍为-1，代表这一行都是正数
                res += Solve(midRow + 1, rightRow, leftCol, rightCol, grid);
            }
            return res;

        }

        // method 3
        // 倒序遍历
        public int CountNegatives_3(int[][] grid)
        {
            int num = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            int pos = cols - 1;
            for (int r = 0; r < rows; r++)
            {
                int c = 0;
                for (c = pos; c >= 0; c--)
                {
                    if (grid[r][c] >= 0)
                    {
                        if (c + 1 < cols) // 即c < cols -1，意思是如果这一行最后一个数都是正数的话，这一行就不用考虑了
                        {
                            pos = c + 1;
                            num += cols - pos;
                        }
                        break;
                    }
                }
                // 即倒序遍历这一行都结束了，都没有出现正数，即这一行都是负数，而且因为知道了这一行都是负数，则后面所有行都肯定是负数
                if (c == -1)
                {
                    num += cols;
                    pos = -1;
                }
            }
            return num;

        }




    }
}