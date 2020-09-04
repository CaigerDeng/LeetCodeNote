using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 剑指 Offer 04. 二维数组中的查找
    /// https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/
    /// </summary>


    public class Solution_Offer_04
    {

        // method 0
        // 暴力 时间复杂度 O(n * m)
        public bool FindNumberIn2DArray_0(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == target)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        // method 1
        // 现行查找 时间复杂度 O(n + m)
        public bool FindNumberIn2DArray_1(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int r = 0;
            int c = cols - 1;
            while (r < rows && c >= 0)
            {
                int num = matrix[r][c];
                if (num == target)
                {
                    return true;
                }
                else if (num > target)
                {
                    c--;
                }
                else
                {
                    r++;
                }
            }
            return false;

        }

        // method 2
        // mine 二分查找
        public bool FindNumberIn2DArray_2(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            // 首先，先在第一行找到合适列
            var para = FindColRangeInFirstRow(matrix, target);
            if (para.Item3)
            {
                return true;
            }
            // 然后，先在合适列找目标值
            if (FindTargetByCol(matrix, target, para.Item1))
            {
                return true;
            }
            if (FindTargetByCol(matrix, target, para.Item2))
            {
                return true;
            }
            return false;

        }

        public Tuple<int, int, bool> FindColRangeInFirstRow(int[][] matrix, int target)
        {
            int left = 0;
            int right = matrix[0].Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int val = matrix[0][mid];
                if (val == target)
                {
                    return new Tuple<int, int, bool>(left, right, true);
                }
                if (left + 1 == right)
                {
                    return new Tuple<int, int, bool>(left, right, false);
                }
                else if (val < mid)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return new Tuple<int, int, bool>(left, right, false);

        }

        public bool FindTargetByCol(int[][] matrix, int target, int col)
        {
            int left = 0;
            int right = matrix.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int val = matrix[mid][col];
                if (val == target)
                {
                    return true;
                }               
                else if (val < mid)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return false;

        }

    }


}