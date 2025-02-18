using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    public class TestMisc
    {
        public void Run()
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic[2] = 5;
            foreach (KeyValuePair<int, int> pair in dic)
            {
                Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            }



        }



        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            bool flagCol0 = false, flagRow0 = false;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    flagCol0 = true;
                }
            }
            for (int j = 0; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    flagRow0 = true;
                }
            }

            Console.WriteLine("1:");
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = matrix[0][j] = 0;
                    }
                }
            }
            Program.PrintMatrix(matrix);

            Console.WriteLine("2:");
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            Program.PrintMatrix(matrix);

            if (flagCol0)
            {
                Console.WriteLine("3:");
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
                Program.PrintMatrix(matrix);
            }

            if (flagRow0)
            {
                Console.WriteLine("4:");
                for (int j = 0; j < n; j++)
                {
                    matrix[0][j] = 0;
                }
                Program.PrintMatrix(matrix);
            }

            Console.WriteLine("999:");
            Program.PrintMatrix(matrix);

        }

        void gameOfLife(int[][] board)
        {
            int[] neighbors = new int[3] { 0, 1, -1 };

            int rows = board.Length;
            int cols = board[0].Length;

            // 创建复制数组 copyBoard
            int[][] copyBoard = new int[rows][];

            // 从原数组复制一份到 copyBoard 中
            for (int row = 0; row < rows; row++)
            {
                copyBoard[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    copyBoard[row][col] = board[row][col];
                }
            }

            // 遍历面板每一个格子里的细胞
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    // 对于每一个细胞统计其八个相邻位置里的活细胞数量
                    int liveNeighbors = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            if (!(neighbors[i] == 0 && neighbors[j] == 0))
                            {
                                int r = (row + neighbors[i]);
                                int c = (col + neighbors[j]);

                                // 查看相邻的细胞是否是活细胞
                                if ((r < rows && r >= 0) && (c < cols && c >= 0) && (copyBoard[r][c] == 1))
                                {
                                    liveNeighbors += 1;
                                }
                            }
                        }
                    }

                    // 规则 1 或规则 3      
                    if ((copyBoard[row][col] == 1) && (liveNeighbors < 2 || liveNeighbors > 3))
                    {
                        board[row][col] = 0;
                    }
                    // 规则 4
                    if (copyBoard[row][col] == 0 && liveNeighbors == 3)
                    {
                        board[row][col] = 1;
                    }
                }
            }

        }



    }




}
