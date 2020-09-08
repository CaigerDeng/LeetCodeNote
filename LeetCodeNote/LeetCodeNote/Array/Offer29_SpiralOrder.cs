namespace LeetCodeNote.Array
{

    /// <summary>
    /// 剑指 Offer 29. 顺时针打印矩阵
    /// https://leetcode-cn.com/problems/shun-shi-zhen-da-yin-ju-zhen-lcof/
    /// </summary>


    public class Solution_Offer29
    {
        // method 0
        public int[] SpiralOrder_0(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new int[0];
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            bool[,] visited = new bool[rows, cols];
            int total = rows * cols;
            int[] res = new int[total];
            int[,] dir = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            int dirIndex = 0;
            int r = 0;
            int c = 0;
            for (int i = 0; i < total; i++)
            {
                res[i] = matrix[r][c];
                visited[r, c] = true;
                int nextRow = r + dir[dirIndex, 0];
                int nextCol = c + dir[dirIndex, 1];
                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || visited[nextRow, nextCol])
                {
                    dirIndex = (dirIndex + 1) % 4;
                }
                r += dir[dirIndex, 0];
                c += dir[dirIndex, 1];
            }
            return res;

        }

        // method 1
        public int[] SpiralOrder_1(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new int[0];
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;           
            int[] res = new int[rows * cols];
            int index = 0;
            int left = 0;
            int right = cols - 1;
            int top = 0;
            int bottom = rows - 1;
            while (left <= right && top <= bottom)
            {
                for (int c = left; c <= right; c++)
                {
                    res[index++] = matrix[top][c];
                }
                for (int r = top + 1; r <= bottom; r++)
                {
                    res[index++] = matrix[r][right];
                }
                if (left < right && top < bottom)
                {
                    for (int c = right - 1; c > left; c--)
                    {
                        res[index++] = matrix[bottom][c];
                    }
                    for (int r = bottom; r > top; r--)
                    {
                        res[index++] = matrix[r][left];
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }          
            return res;

        }


    }
}