namespace LeetCodeNote.Array
{
    /// <summary>
    /// 832. 翻转图像
    /// https://leetcode-cn.com/problems/flipping-an-image/
    /// </summary>

    public class Solution_832
    {

        // method 0 
        public int[][] FlipAndInvertImage_0(int[][] A)
        {
            int c = A[0].Length; //列
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < (c + 1) / 2; j++)
                {
                    int temp = A[i][j] ^ 1;
                    A[i][j] = A[i][c - 1 - j] ^ 1;
                    A[i][c - 1 - j] = temp;
                }
            }
            return A;
        }



    }



}