using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 54. 螺旋矩阵
    /// https://leetcode.cn/problems/spiral-matrix/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_54
    {

        public void Run()
        {
            //int[][] matrix = new int[][]
            //{
            //    new int[] { 1, 2, 3 },
            //    new int[] { 4, 5, 6 },
            //    new int[] { 7, 8, 9 },
            //}; // res:[1,2,3,6,9,8,7,4,5]

            int[][] matrix = new int[][]
            {
                new int[] { 1,2,3,4 },
                new int[] { 5,6,7,8 },
                new int[] { 9,10,11,12 },
            }; // res:[1,2,3,4,8,12,11,10,9,5,6,7]

            //int[][] matrix = new int[][]
            //{
            //    new int[] { 2,3},
            //}; // res:[2,3]

            //int[][] matrix = new int[][]
            //{
            //    new int[] { 1,2,3,4 },
            //    new int[] { 5,6,7,8 },
            //    new int[] { 9,10,11,12 },
            //    new int[] { 13,14,15,16 },
            //    new int[] { 17,18,19,20},
            //    new int[] { 21,22,23,24},

            //}; // res:[1, 2, 3, 4, 8, 12, 16, 20, 24, 23, 22, 21, 17, 13, 9, 5, 6, 7, 11, 15, 19, 18, 14, 10]


            List<int> res = (List<int>)SpiralOrder_My_0(matrix);
            Program.PrintList(res);

        }

        // (2025/2/11) method My 0-我的题解0
        // 按题意顺时针样式行走取值
        // 时间复杂度：O(N)，空间复杂度：O(N)（N为矩阵大小）
        public IList<int> SpiralOrder_My_0(int[][] matrix)
        {
            // m行
            int m = matrix.Length;
            // n列
            int n = matrix[0].Length;
            int count = m * n;
            List<int> resList = new List<int>();
            // 1横着走，-1竖着走
            int horizontal = 1;
            // 1往大（向右/向下）走，-1往小（向左/向上）走
            int changeDir = 1;
            // upEdge <= row <= downEdge
            int upEdge = 0;
            int downEdge = m - 1;
            // leftEdge <= col <= rightEdge
            int leftEdge = 0;
            int rightEdge = n - 1;
            int row = 0;
            int col = 0;
            int num = 0;
            int cornerNum = 0;
            bool isNewCircle = false;
            while (num < count)
            {
                int v = matrix[row][col];
                resList.Add(v);
                // 左上角，向右走
                if (row == upEdge && col == leftEdge)
                {
                    horizontal = 1;
                    changeDir = 1;
                    cornerNum++;
                }
                // 右上角，向下走
                if (row == upEdge && col == rightEdge)
                {
                    horizontal = -1;
                    changeDir = 1;
                    cornerNum++;
                }
                // 右下角，向左走
                if (m > 1 && row == downEdge && col == rightEdge)
                {
                    horizontal = 1;
                    changeDir = -1;
                    cornerNum++;
                }
                // 左下角，向上走
                if (m > 1 && row == downEdge && col == leftEdge)
                {
                    horizontal = -1;
                    changeDir = -1;
                    cornerNum++;
                }
                if (horizontal == 1)
                {
                    col += changeDir;
                }
                else
                {
                    row += changeDir;
                }
                // 刚过这一圈的左下角，即四个顶点都走过
                if (cornerNum > 0 && cornerNum % 4 == 0 && !isNewCircle)
                {
                    isNewCircle = true;
                    upEdge++;
                    rightEdge--;
                    cornerNum = 0;
                }
                // 刚过新一圈的右上角
                if (isNewCircle && cornerNum == 2)
                {
                    leftEdge++;
                    downEdge--;
                    isNewCircle = false;
                }
                num++;
            }
            return resList;

        }


        // method 1-官方题解1
        // 也是按顺时针样式行走，记录已访问元素来转变方向！
        // 比“官方题解2”更好，因为更好读懂更少代码
        // 时间复杂度：O(N)，空间复杂度：O(N)（N为矩阵大小）
        public IList<int> SpiralOrder_1(int[][] matrix)
        {
            List<int> resList = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return resList;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            // 官方用的是交错数组，我这里用二维数组少写一些声明代码
            // 记录已经访问的元素（比“我的题解0”判断四个角再缩边界的写法简洁多了！）
            bool[,] visitedMatrix = new bool[rows, cols];
            int total = rows * cols;
            int row = 0;
            int col = 0;
            // (row, col)变化方向
            int[,] dirArr = new int[4, 2]
            {
                // 严格按顺时针顺序写好
                {0, 1}, // 向右
                {1, 0}, // 向下
                {0, -1},// 向左
                {-1, 0} // 向上
            };
            int dirIndex = 0;
            for (int i = 0; i < total; i++)
            {
                resList.Add(matrix[row][col]);
                visitedMatrix[row, col] = true;
                int nextRow = row + dirArr[dirIndex, 0];
                int nextCol = col + dirArr[dirIndex, 1];
                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || visitedMatrix[nextRow, nextCol])
                {
                    dirIndex = (dirIndex + 1) % 4;
                }
                row += dirArr[dirIndex, 0];
                col += dirArr[dirIndex, 1];
            }
            return resList;

        }

        // method 2-官方题解2
        // 也是按顺时针样式行走，每次走多少是算好的
        // 和“我的题解0”思路一样，写法不一样
        // 时间复杂度：O(N)，空间复杂度：O(N)（N为矩阵大小）
        public IList<int> SpiralOrder_2(int[][] matrix)
        {
            List<int> resList = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return resList;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int left = 0;
            int right = cols - 1;
            int top = 0;
            int bottom = rows - 1;
            while (left <= right && top <= bottom)
            {
                // 从左上角往右走，走到右上角
                for (int col = left; col <= right; col++)
                {
                    resList.Add(matrix[top][col]);
                }
                // 从右上角的下方单位往下走，走到右下角
                for (int row = top + 1; row <= bottom; row++)
                {
                    resList.Add(matrix[row][right]);
                }
                if (left < right && top < bottom)
                {
                    // 从右下角的左侧单位往左走，走到左下角的右侧单位
                    for (int col = right - 1; col > left; col--)
                    {
                        resList.Add(matrix[bottom][col]);
                    }
                    // 从左下角往上走，走到左上角的下侧单位
                    for (int row = bottom; row > top; row--)
                    {
                        resList.Add(matrix[row][left]);
                    }
                }
                // 缩小边界
                left++;
                right--;
                top++;
                bottom--;
            }
            return resList;

        }





    }


}
