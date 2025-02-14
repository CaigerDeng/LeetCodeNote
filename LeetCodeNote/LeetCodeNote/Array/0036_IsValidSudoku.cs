using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 36. 有效的数独
    /// https://leetcode.cn/problems/valid-sudoku/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_36
    {

        public void Run()
        {
            // 举例：如果board是二维数组，它的初始化如下
            char[,] boardExample = new char[,]
            {
                { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            // [][]交错数组，每一行的子数组可以有不同长度；和[,]二维数组不同
            // 交错数组初始化
            //char[][] board = new char[9][]
            //{
            //    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            //    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            //    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            //    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            //    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            //    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            //    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            //    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            //    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            //}; //res true


            char[][] board = new char[9][]
            {
                new char[] { '.', '.', '.', '.', '5', '.', '.', '1', '.' },
                new char[] { '.', '4', '.', '3', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '3', '.', '.', '1' },
                new char[] { '8', '.', '.', '.', '.', '.', '.', '2', '.' },
                new char[] { '.', '.', '2', '.', '7', '.', '.', '.', '.' },
                new char[] { '.', '1', '5', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '2', '.', '.', '.' },
                new char[] { '.', '2', '.', '9', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '4', '.', '.', '.', '.', '.', '.' }
            }; // res:false


            bool res = IsValidSudoku_My_0(board);
            Console.WriteLine("res:{0}", res);

        }

        // (2025/2/11) method My 0-我的题解0
        // 照题意直写，没啥技巧
        // 时间复杂度：O(1)，空间复杂度：O(1)
        public bool IsValidSudoku_My_0(char[][] board)
        {
            HashSet<Char> hashSet = new HashSet<Char>();
            // 数字 1-9 在每一行只能出现一次
            for (int row = 0; row < 9; row++)
            {
                hashSet.Clear();
                for (int col = 0; col < 9; col++)
                {
                    char c = board[row][col];
                    if (c != '.')
                    {
                        if (!hashSet.Add(c))
                        {
                            return false;
                        }
                    }
                }
            }
            hashSet.Clear();
            // 数字 1-9 在每一列只能出现一次
            for (int col = 0; col < 9; col++)
            {
                hashSet.Clear();
                for (int row = 0; row < 9; row++)
                {
                    char c = board[row][col];
                    if (c != '.')
                    {
                        if (!hashSet.Add(c))
                        {
                            return false;
                        }
                    }
                }
            }
            hashSet.Clear();
            // 数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次
            for (int i = 0; i < 9; i++) // 从左往右扫描，有9个3X3矩阵
            {
                hashSet.Clear();
                // row都是按第i个3X3矩阵算出来的规律
                for (int row = i - i % 3; row < i - i % 3 + 3; row++)
                {
                    // col都是按第i个3X3矩阵算出来的规律
                    for (int col = i % 3 * 3; col < i % 3 * 3 + 3; col++)
                    {
                        char c = board[row][col];
                        if (c != '.')
                        {
                            if (!hashSet.Add(c))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }

        // method 1-官方题解1
        // 官方不用哈希表而是用了好几个多维数组来记录数组，代码很简洁，我改了一下数字记录范围这样比较直观
        // 时间复杂度：O(1)，空间复杂度：O(1)
        public bool IsValidSudoku_1(char[][] board)
        {
            // 每一行所有可能出现的数字
            int[,] rows = new int[9, 9 + 1];
            // 每一列所有可能出现的数字
            int[,] cols = new int[9, 9 + 1];
            // 每一个3X3矩阵中所有可能出现的数字，前两项是3X3矩阵中的坐标
            int[,,] subboxes = new int[3, 3, 9 + 1];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char c = board[i][j];
                    if (c != '.')
                    {
                        int index = c - '0';
                        rows[i, index]++;
                        cols[j, index]++;
                        subboxes[i / 3, j / 3, index]++;
                        if (rows[i, index] > 1 || cols[j, index] > 1 || subboxes[i / 3, j / 3, index] > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }






    }



}
