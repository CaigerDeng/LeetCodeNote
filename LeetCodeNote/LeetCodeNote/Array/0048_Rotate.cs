using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 48. 旋转图像
    /// https://leetcode.cn/problems/rotate-image/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_48
    {

        public void Run()
        {
            int[][] matrix = new int[][]
            {
                new int[] { 1,2,3},
                new int[] { 4,5,6},
                new int[] { 7,8,9},
            };



            Rotate_My_0(matrix);

            PrintMatrix(matrix);

        }

        private void PrintMatrix(int[][] matrix)
        {
            int n = matrix.Length;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row][col] + ",");
                }
                Console.WriteLine();
            }

        }

        // (2025/2/11) method My 0-我的题解0
        // （以下只是尝试代码，不知道怎么用代码写：我打算从外往内一层层转，对这一层而言一次只移动一个元素。）
        // 时间复杂度：O(?)，空间复杂度：O(?)
        public void Rotate_My_0(int[][] matrix)
        {
            int n = matrix.Length;
            int level = n / 2;
            int[,] dirArr = new int[4, 2]
            {
                // 严格按顺时针顺序写好
                {0, 1}, // 向右
                {1, 0}, // 向下
                {0, -1},// 向左
                {-1, 0} // 向上
            };
            int leftEdge = 0;
            int rightEdge = n - 1;
            int topEdge = 0;
            int bottomEdge = n - 1;
            int row = 0;
            int col = 0;
            for (int i = 0; i < level; i++)
            {
                // 四个方向同时走
                for (int j = 0; j < 4; j++)
                {
                    int dirIndex = j;
                    int nextRow = row + dirArr[dirIndex, 0];
                    int nextCol = col + dirArr[dirIndex, 1];
                    if (nextRow < topEdge || nextRow > bottomEdge || nextCol < leftEdge || nextCol > rightEdge)
                    {
                        dirIndex = (dirIndex + 1) % 4;
                    }
                    nextRow = row + dirArr[dirIndex, 0];
                    nextCol = col + dirArr[dirIndex, 1];
                    matrix[nextRow][nextCol] = matrix[row][col];
                }
                // 缩小边界
                leftEdge++;
                rightEdge--;
                topEdge++;
                bottomEdge--;
            }

        }

        // method 1-官方题解1
        // 把每一行变成每一列，用额外数组辅助
        // 没问题但不合题意对“原地”要求
        // 时间复杂度：O(N*N)，空间复杂度：O(N*N) (N为矩阵大小）
        public void Rotate_1(int[][] matrix)
        {
            int n = matrix.Length;
            int[,] matrixNew = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixNew[j, n - i - 1] = matrix[i][j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = matrixNew[i, j];
                }
            }

        }

        // method 2-官方题解2
        // 原地旋转
        // 时间复杂度：O(N*N)，空间复杂度：O(1) (N为矩阵大小）
        public void Rotate_2(int[][] matrix)
        {
            int n = matrix.Length;
            // 因为一次旋转要动四个元素，就相当于把整个矩阵均分为4份，只要动前四分之一部分，其他部分就会自动更新。
            // 那下面的两层for循环就是确定了这前四分之一部分的行是多少、列是多少。
            // 注意：i < n / 2
            for (int i = 0; i < n / 2; i++)
            {
                // 注意：i < j < (n + 1) / 2
                for (int j = 0; j < (n + 1) / 2; j++)
                {
                    // 对每一个元素，涉及到四个元素的交换
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - j - 1][i];
                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                    matrix[j][n - i - 1] = temp;
                }
            }

        }

        // method 3-官方题解3
        // 先水平翻转（想象有一条水平线），再对角线翻转
        // 时间复杂度：O(N*N)，空间复杂度：O(1) (N为矩阵大小）
        public void Rotate_3(int[][] matrix)
        {
            int n = matrix.Length;
            // 先水平翻转
            // 注意：i < n / 2
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    (matrix[i][j], matrix[n - i - 1][j]) = (matrix[n - i - 1][j], matrix[i][j]);
                }
            }
            // 再对角线（从左上角到右下角）翻转
            // 注意：i < n
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }

        }




    }


}
