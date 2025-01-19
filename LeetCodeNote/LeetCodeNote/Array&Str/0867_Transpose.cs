namespace LeetCodeNote.Array
{
    /// <summary>
    /// 867. 转置矩阵
    /// https://leetcode-cn.com/problems/transpose-matrix/
    /// </summary>

    public class Solution_867
    {
        // method 0
        public int[][] Transpose_0(int[][] A)
        {
            int R = A.Length;
            int C = A[0].Length;
            int[][] res = new int[C][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[R];
            }
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    res[c][r] = A[r][c];
                }             
            }
            return res;
        }




    }


}