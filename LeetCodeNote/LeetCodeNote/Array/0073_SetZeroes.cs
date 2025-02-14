using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 73. 矩阵置零
    /// https://leetcode.cn/problems/set-matrix-zeroes/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_73
    {

        public void Run()
        {

        }

        // (2025/2/13) method My 0-我的题解0
        // 没想出来合适的设计，如果矩阵是从左到右从上到下遍历的话，肯定会读到0，无法判断这个0是老0还是新0
        public void SetZeroes_My_0(int[][] matrix)
        {
            // 没成功的设计：
            // 设计1：不需要原地的话，我可以用列表来记录矩阵中出现0的位置，可惜题意要求“原地”。
            // 设计2：用原地的话，把原先的0换成矩阵里元素最大值+1，但如果有元素是int.MaxValue的话这个设计就会失效。

        }

        // method 1-官方题解1
        // 不符题意“原地”要求！使用数组记录老0
        // 时间复杂度：O(m*n)，空间复杂度：O(m+n)
        public void SetZeroes_1(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool[] rowArr = new bool[m];
            bool[] colArr = new bool[n];
            // 记录老0所在的行与列
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rowArr[i] = true;
                        colArr[j] = true;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rowArr[i] || colArr[j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

        }

        // method 2-官方题解2
        // 使用两个标记变量。先忽略第一行与第一列，在剩下的矩形中如果出现老0，则对应的行列值变0；再考虑第一行第一列是否有老0，有就补上对应行列变化。
        // 时间复杂度：O(m*n)，空间复杂度：O(1)
        public void SetZeroes_2(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool isFirstRowHasZero = false;
            bool isFirstColHasZero = false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[0][i] == 0)
                {
                    isFirstRowHasZero = true;
                    break;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isFirstColHasZero = true;
                    break;
                }
            }
            // 忽略第一行第一列，在剩下的矩形中如果有0，则标记对应行的行头为0，对应列的列头为0
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            // 在剩下的矩形中，如果某单位对应行的行头为0/对应列的列头为0，则该单位变0。
            // 这里包含了第一行如果有0则对应列变0、第一列如果有0则对应行变0的情况。
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

            if (isFirstRowHasZero)
            {
                // 如果第一行有老0，则第一行都变0
                for (int i = 0; i < n; i++)
                {
                    matrix[0][i] = 0;
                }
            }
            if (isFirstColHasZero)
            {
                // 如果第一列有老0，则第一列都变0
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }

        }

        // method 3-官方题解3
        // （不推荐阅读）对“官方题解2”的优化，少用一个标记，但性能不变，还更难理解了。
        // 时间复杂度：O(m*n)，空间复杂度：O(1)
        public void SetZeroes_3(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool isFirstColHasZero = false;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isFirstColHasZero = true;
                }
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][ j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            // 倒序原因：如果是正序，那如果第一行有老o，则对应行列变新0；在下一次循环中元素会受到这些新0影响而变化，但这种变化是不应该出现的。
            // 见网友解释：https://leetcode.cn/problems/set-matrix-zeroes/solutions/669901/ju-zhen-zhi-ling-by-leetcode-solution-9ll7/comments/845025
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
                if (isFirstColHasZero)
                {
                    matrix[i][0] = 0;
                }
            }

        }



    }


}
