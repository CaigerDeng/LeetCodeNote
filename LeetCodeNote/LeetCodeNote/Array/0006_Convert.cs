using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 6. Z 字形变换
    /// https://leetcode.cn/problems/zigzag-conversion/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_6
    {
        public void Run()
        {
            string s = "PAYPALISHIRING";
            string res = Convert_2(s, 4);
            Console.WriteLine("res:{0}", res);




        }


        // 我的题解0，没有特别算法，按题意直写
        // 说是“Z 字形”，其实更像是“N字形”。
        // 构造二维矩阵来填充字符
        // 时间复杂度：O(r*n)， 空间复杂度：O(r*n)
        public string Convert_My_0(string s, int numRows)
        {
            if (s.Length == 1 || numRows == 1 || numRows >= s.Length)
            {
                // 对于字符串长度为1，或者只有一行，或者只有一列的情况
                return s;
            }
            int numCols = 1000;
            char[,] arr = new char[numRows, numCols];
            int i = 0;
            int row = 0;
            int col = 0;
            bool isDown = true;
            while (i < s.Length)
            {
                arr[row, col] = s[i];
                i++;
                if (isDown)
                {
                    // 竖着那一列
                    row++;
                }
                else
                {
                    // 斜着那一列
                    row--;
                    col++;
                }
                // 开始斜着那一列
                if (row == numRows)
                {
                    isDown = false;
                    row = numRows - 2;
                    col++;
                }
                // 开始竖着那一列
                if (row < 0)
                {
                    isDown = true;
                    row = 1;
                    col--; // 去掉前面多算的一行
                }
            }

            ///////////////////////////// debug
            //PrintArr(arr, 30);

            StringBuilder sb = new StringBuilder();
            for (row = 0; row < numRows; row++)
            {
                for (col = 0; col < numCols; col++)
                {
                    char c = arr[row, col];
                    if (c != 0)
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();

        }

        private void PrintArr(char[,] arr, int fixCols = 0)
        {
            int numRows = arr.GetLength(0);
            int numCols = fixCols > 0 ? fixCols : arr.GetLength(1);
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    char c = arr[row, col];
                    Console.Write(c != 0 ? c : '*');
                }
                Console.WriteLine();
                Console.WriteLine();
            }

        }

        // 官方题解1 
        // 思路和“我的题解0”一致，不过官方算出了二维矩阵的限制列数，往数组里填充字符的过程写的也更简洁
        // 因为缩小了矩阵容量，因此“官方题解1”比“我的题解0”明显快
        // 这里细节和官方略有不同，我没有像官方那样用交错数组而是用多维数组
        // 时间复杂度：O(r*n)， 空间复杂度：O(r*n)
        public string Convert_1(string s, int numRows)
        {
            int n = s.Length;
            if (numRows == 1 || numRows >= n)
            {
                // 或者只有一行，或者只有一列（字符串长度为1的情况也被包含）的情况
                return s;
            }
            // 周期t（有多少字符） = 一竖 + 一斜，即numRows + (numRows - 2)
            int t = numRows * 2 - 2;
            // 一个周期占 1 + (numRows-2)列，即 numRows - 1
            // 程序中/除法是向下取整，但是题目的总周期需要向上取整，即(n + t - 1) / t，这是一个向上取整公式（详细解释见ChatGPT）
            // 因此总列数=总周期*一个周期所占列
            int numCols = (n + t - 1) / t * (numRows - 1);
            char[,] mat = new char[numRows, numCols];
            for (int i = 0, x = 0, y = 0; i < n; i++)
            {
                mat[x, y] = s[i];
                if (i % t < numRows - 1)
                {
                    // 向下移动
                    x++;
                }
                else
                {
                    // 向右上移动
                    x--;
                    y++;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    char c = mat[row, col];
                    if (c != 0)
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();

        }

        // 官方题解2 
        // “官方题解1”的优化，压缩矩阵空间
        // 以每行从左往右的角度观察矩阵，发现每次填充的字符就是加在每行的末尾，那么把每行简化为一个列表（代码中用的是StringBuilder）即可
        // 时间复杂度：O(n)， 空间复杂度：O(n)
        public string Convert_2(string s, int numRows)
        {
            int n = s.Length;
            if (numRows == 1 || numRows >= n)
            {
                // 或者只有一行，或者只有一列（字符串长度为1的情况也被包含）的情况
                return s;
            }
            // 周期t = 一竖 + 一斜，即numRows + (numRows - 2)
            int t = numRows * 2 - 2;
            StringBuilder[] mat = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
            {
                mat[i] = new StringBuilder();
            }
            for (int i = 0, x = 0; i < n; i++)
            {
                mat[x].Append(s[i]);
                if (i % t < numRows - 1)
                {
                    // 向下移动
                    x++;
                }
                else
                {
                    // 向右上移动
                    x--;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (StringBuilder row in mat)
            {
                sb.Append(row);
            }
            return sb.ToString();

        }

        // 官方题解3
        // 找数学规律，其实还是看矩阵
        // 以每行从左往右的角度观察矩阵，每个周期开头肯定要加入；假设此行索引为i，在周期A与周期B的间隔，会发现这中间的字符索引就是同行打头的值往后平移若干个单位，
        // 具体移动单位与周期和当前行索引相关，公式为j + t - i
        // （测试结果是最快的！）时间复杂度：O(n)， 空间复杂度：O(1)
        public string Convert_3(string s, int numRows)
        {
            int n = s.Length;
            if (numRows == 1 || numRows >= n)
            {
                // 或者只有一行，或者只有一列（字符串长度为1的情况也被包含）的情况
                return s;
            }
            // 周期t（有多少字符） = 一竖 + 一斜，即numRows + (numRows - 2)
            int t = numRows * 2 - 2;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numRows; i++) // 一行一行扫描
            {
                for (int j = 0; j + i < n; j += t)
                {
                    // 针对第一行和最后一行
                    sb.Append(s[j + i]);
                    // 针对第二行到倒数第二行，填入周期A与周期B中间的字符
                    if (0 < i && i < numRows - 1 && j + t - i < n)
                    {
                        sb.Append(s[j + t - i]);
                    }
                }
            }
            return sb.ToString();

        }



    }

}
