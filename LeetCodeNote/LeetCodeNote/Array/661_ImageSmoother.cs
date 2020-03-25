namespace LeetCodeNote.Array
{
    /// <summary>
    /// 661. 图片平滑器
    /// https://leetcode-cn.com/problems/image-smoother/
    /// </summary>


    public class Solution_661
    {
        // method 0
        // 大脑想法直译
        public int[][] ImageSmoother_0(int[][] M)
        {
            int R = M.Length; // row
            int C = M[0].Length; // col
            int[][] res = new int[R][];
            for (int i = 0; i < R; i++)
            {
                res[i] = new int[C];
            }
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    int count = 0;
                    for (int rr = r - 1; rr <= r + 1; rr++)
                    {
                        for (int cc = c - 1; cc <= c + 1; cc++)
                        {
                            if (0 <= rr && rr < R && 0 <= cc && cc < C)
                            {
                                res[r][c] += M[rr][cc];
                                count++;
                            }
                        }
                    }
                    res[r][c] /= count;
                }
            }
            return res;
        }

    }


}