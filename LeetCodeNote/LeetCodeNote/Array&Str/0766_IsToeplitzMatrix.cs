using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 766. 托普利茨矩阵
    /// https://leetcode-cn.com/problems/toeplitz-matrix/
    /// </summary>

    public class Solution_766
    {
        // method 0
        // 让 dic[r-c] 存储每条对角线上遇到的第一个元素的值
        public bool IsToeplitzMatrix_0(int[][] matrix)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (!dic.ContainsKey(r - c))
                    {
                        dic.Add(r - c, matrix[r][c]);
                    }
                    else if (dic[r - c] != matrix[r][c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // method 1
        public bool IsToeplitzMatrix_1(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (r > 0 && c > 0 && matrix[r - 1][c - 1] != matrix[r][c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }






    }






}
