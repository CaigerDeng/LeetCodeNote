using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 566. 重塑矩阵
    /// https://leetcode-cn.com/problems/reshape-the-matrix/
    /// </summary>

    public class Solution_566
    {
        // method 0 
        public int[][] MatrixReshape_0(int[][] nums, int r, int c)
        {
            // int[][]交错数组
            // int[][] arr = new int[5][]; // 5代表有arr[0]，arr[1]，arr[2]，arr[3]，arr[4]，arr.Length就代表数组行
            // arr[0] = new int[] { 1, 2 };
            // arr[1] = new int[] { 3, 4, 5 };
            // Console.WriteLine("{0}, {1}, {2}", arr.Length, arr[0].Length, arr[1].Length); // 输出：5, 2, 3 

            if (nums.Length == 0 || r * c != nums.Length * nums[0].Length)
            {
                return nums;
            }
            int[][] res = new int[r][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[c];
            }
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    queue.Enqueue(nums[i][j]);
                }
            }
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    res[i][j] = queue.Dequeue();
                }
            }
            return res;
        }

        // method 1
        // 对method 0优化了队列
        public int[][] MatrixReshape_1(int[][] nums, int r, int c)
        {
            if (nums.Length == 0 || r * c != nums.Length * nums[0].Length)
            {
                return nums;
            }
            int[][] res = new int[r][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[c];
            }
            int rows = 0;
            int cols = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    res[rows][cols] = nums[i][j];
                    cols++;
                    if (cols == c)
                    {
                        rows++;
                        cols = 0;
                    }
                }
            }
            return res;
        }

        // method 2
        // 对method 1优化了行列检查
        public int[][] MatrixReshape_2(int[][] nums, int r, int c)
        {
            if (nums.Length == 0 || r * c != nums.Length * nums[0].Length)
            {
                return nums;
            }
            int[][] res = new int[r][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[c];
            }
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    res[count / c][count % c] = nums[i][j];
                    count++;
                }
            }
            return res;
        }





    }









}