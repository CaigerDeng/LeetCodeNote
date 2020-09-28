using System.Collections.Generic;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 1582. 二进制矩阵中的特殊位置
    /// https://leetcode-cn.com/problems/special-positions-in-a-binary-matrix/
    /// </summary>


    public class Solution_1582
    {
        // method 0
        // mine
        public int NumSpecial_0(int[][] mat)
        {
            // 选出答案所在列
            List<int> chooseColList = new List<int>();
            int rows = mat.Length;
            int cols = mat[0].Length;
            for (int r = 0; r < rows; r++)
            {
                int time = 0;
                int selectedC = -1;
                for (int c = 0; c < cols; c++)
                {
                    if (mat[r][c] == 1)
                    {
                        time++;
                        if (time == 1)
                        {
                            selectedC = c;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (time == 1)
                {
                    chooseColList.Add(selectedC);
                }
            }
            int res = 0;
            for (int i = 0; i < chooseColList.Count; i++)
            {
                int c = chooseColList[i];
                int time = 0;
                for (int r = 0; r < rows; r++)
                {
                    if (mat[r][c] == 1)
                    {
                        time++;
                        if (time >= 2)
                        {
                            break;
                        }
                    }
                }
                if (time == 1)
                {
                    res++;
                }
            }
            return res;

        }

        // method 1
        public int NumSpecial_1(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            int[] rowArr = new int[rows];
            int[] colsArr = new int[cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int val = mat[r][c];
                    rowArr[r] += val;
                    colsArr[c] += val;

                }
            }
            int res = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int val = mat[r][c];
                    if (val == 1 && rowArr[r] == 1 && colsArr[c] == 1)
                    {
                        res++;
                    }
                }
            }
            return res;
        }

    }



}