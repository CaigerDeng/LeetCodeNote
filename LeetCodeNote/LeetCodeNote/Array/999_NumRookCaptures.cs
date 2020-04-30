namespace LeetCodeNote.Array
{
    /// <summary>
    /// 999. 可以被一步捕获的棋子数
    /// https://leetcode-cn.com/problems/available-captures-for-rook/
    /// </summary>

    public class Solution_999
    {
        // method 0
        // 直译，直接计算白车的四个方向移动
        public int NumRookCaptures_0(char[][] board)
        {
            int res = 0;
            int x = 0;
            int y = 0;
            int[] dx = new[] { -1, 0, 0, 1 };
            int[] dy = new[] { 0, -1, 1, 0 };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // 找到自己白车
                    if (board[i][j] == 'R')
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int step = 0; ; step++)
                {
                    int tx = x + step * dx[i];
                    int ty = y + step * dy[i];
                    // 遇到友方白象
                    if (tx < 0 || tx >= 8 || ty < 0 || ty >= 8 || board[tx][ty] == 'B')
                    {
                        break;
                    }
                    // 遇到黑卒
                    if (board[tx][ty] == 'p')
                    {
                        res++;
                        break;
                    }
                }
            }
            return res;

        }

    }
}