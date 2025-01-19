namespace LeetCodeNote.Array
{

    /// <summary>
    /// 1572. 矩阵对角线元素的和
    /// https://leetcode-cn.com/problems/matrix-diagonal-sum/
    /// </summary>


    public class Solution_1572
    {
        // method 0
        public int DiagonalSum_0(int[][] mat)
        {
            int len = mat.Length;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                res += mat[i][i] + mat[i][len - 1 - i];
            }
            if (len % 2 == 1)
            {
                res -= mat[len / 2][len / 2];
            }
            return res;

        }



    }

}