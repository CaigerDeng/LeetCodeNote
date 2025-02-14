using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 289. 生命游戏
    /// https://leetcode.cn/problems/game-of-life/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_289
    {

        public void Run()
        {
            int[][] board = new[]
            {
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 1 },
                new int[] { 1, 1, 1 },
                new int[] { 0, 0, 0 },
            };



            GameOfLife_My_0(board);
            Program.PrintMatrix(board);


        }

        // (2025/2/13) method My 0-我的题解0
        // 按题意直写，矩阵中已经访问的值变为特殊值，最后统一修正矩阵
        // 时间复杂度：O(m*n)，空间复杂度：O(1)
        public void GameOfLife_My_0(int[][] board)
        {
            // 8个方向，一个方向有2个坐标
            int[,] dirArr = new int[8, 2]
            {
                {-1, -1}, // 左上
                {-1,  0}, // 上
                {-1,  1}, // 右上

                {0,  -1}, // 左
                {0,   1}, // 右
                
                {1,  -1}, // 左下
                {1,   0}, // 下
                {1,   1}, // 右下
            };
            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int oriNum = board[i][j];
                    int num = GetState(oriNum, i, j, board, dirArr);
                    board[i][j] = num;
                }
            }
            // 修正回用0、1的显示
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = FixNum(board[i][j]);
                }
            }

        }

        // 按游戏规则，访问周围8格，决定自身状态
        private int GetState(int oriNum, int row, int col, int[][] board, int[,] dirArr)
        {
            int m = board.Length;
            int n = board[0].Length;
            int liveCount = 0;
            for (int i = 0; i < dirArr.GetLength(0); i++)
            {
                int rowNei = row + dirArr[i, 0];
                int colNei = col + dirArr[i, 1];
                if (rowNei < 0 || rowNei >= m || colNei < 0 || colNei >= n)
                {
                    continue;
                }
                int neighbor = GetOriNum(board[rowNei][colNei]);
                if (neighbor == 1)
                {
                    liveCount++;
                }
            }
            // 游戏规则
            if (oriNum == 1)
            {
                if (liveCount < 2)
                {
                    return ChangeOriNum(oriNum, true);
                }
                if (liveCount == 2 || liveCount == 3)
                {
                    return ChangeOriNum(oriNum, false);
                }
                if (liveCount > 3)
                {
                    return ChangeOriNum(oriNum, true);
                }
            }
            else
            {
                if (liveCount == 3)
                {
                    return ChangeOriNum(oriNum, true);
                }
            }
            return ChangeOriNum(oriNum, false);

        }

        private int ChangeOriNum(int oriNum, bool isChange)
        {
            if (!isChange)
            {
                switch (oriNum)
                {
                    // 不变，在原值基础上加2
                    case 0:
                        return 2;
                    case 1:
                        return 3;
                }
            }
            else
            {
                switch (oriNum)
                {
                    // 变了，在原值基础上减2
                    case 0:
                        return -2;
                    case 1:
                        return -1;
                }
            }
            return int.MaxValue;

        }

        private int GetOriNum(int num)
        {
            switch (num)
            {
                // 不变
                case 2:
                    return 0;
                case 3:
                    return 1;

                // 变了
                case -2:
                    return 0;
                case -1:
                    return 1;
            }
            // 如果上面都不满足，就说明矩阵中这个值没被访问过
            return num;

        }

        private int FixNum(int num)
        {
            switch (num)
            {
                // 不变
                case 2:
                    return 0;
                case 3:
                    return 1;

                // 变了
                case -2:
                    return 1;
                case -1:
                    return 0;
            }
            return num;

        }

        // method 1-官方题解1
        // 用了辅助数组来记录原矩阵，没问题但不符合题目要求“原地”解法
        // 时间复杂度：O(m*n)，空间复杂度：O(m*n)
        public void GameOfLife_1(int[][] board)
        {
            int[] neighbors = new int[3] { -1, 0, 1 };
            int rows = board.Length;
            int cols = board[0].Length;
            // 用辅助数组来记录原矩阵
            int[][] copyBoard = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                copyBoard[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    copyBoard[row][col] = board[row][col];
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int liveNeighbors = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!(neighbors[i] == 0 && neighbors[j] == 0))
                            {
                                // 不是自身
                                int r = row + neighbors[i];
                                int c = col + neighbors[j];
                                // 查看相邻的细胞是否是活细胞
                                if ((0 <= r && r < rows) && (0 <= c && c < cols) && (copyBoard[r][c] == 1))
                                {
                                    liveNeighbors += 1;
                                }
                            }
                        }
                    }
                    // 只记录发生变化的两种状态：死的活了；活的死了     
                    if (copyBoard[row][col] == 1 && (liveNeighbors < 2 || liveNeighbors > 3))
                    {
                        board[row][col] = 0;
                    }
                    if (copyBoard[row][col] == 0 && liveNeighbors == 3)
                    {
                        board[row][col] = 1;
                    }
                }
            }

        }

        // method 2-官方题解2
        // 和“我的题解0”思路一样，都是用特别数字来表示状态。官方写的更好更简洁，因为只需要记录变了的元素，“我的题解0”多记了不变的元素。
        // 时间复杂度：O(m*n)，空间复杂度：O(1)
        public void GameOfLife_2(int[][] board)
        {
            int[] neighbors = new int[3] { -1, 0, 1 };
            int rows = board.Length;
            int cols = board[0].Length;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int liveNeighbors = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!(neighbors[i] == 0 && neighbors[j] == 0))
                            {
                                // 不是自身
                                int r = row + neighbors[i];
                                int c = col + neighbors[j];
                                // 查看相邻的细胞是否是活细胞
                                if ((0 <= r && r < rows) && (0 <= c && c < cols) && (Math.Abs(board[r][c]) == 1))
                                {
                                    liveNeighbors += 1;
                                }
                            }
                        }
                    }
                    // 只记录发生变化的两种状态：死的活了；活的死了     
                    if (board[row][col] == 1 && (liveNeighbors < 2 || liveNeighbors > 3))
                    {
                        // 活的死了，1变-1
                        board[row][col] = -1;
                    }
                    if (board[row][col] == 0 && liveNeighbors == 3)
                    {
                        // 死的活了，0变2
                        board[row][col] = 2;
                    }
                }
            }
            // 遍历 board 得到一次更新后的状态
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (board[row][col] > 0)
                    {
                        board[row][col] = 1;
                    }
                    else
                    {
                        board[row][col] = 0;
                    }
                }
            }

        }


    }


}
