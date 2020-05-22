namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1232. 缀点成线
    /// https://leetcode-cn.com/problems/check-if-it-is-a-straight-line/
    /// </summary>

    public class Solution_1232
    {
        // method 0
        public bool CheckStraightLine_0(int[][] coordinates)
        {
            int k1 = coordinates[1][0] - coordinates[0][0];
            int k2 = coordinates[1][1] - coordinates[0][1];
            for (int i = 2; i < coordinates.Length; i++)
            {
                if ((coordinates[i][0] - coordinates[i - 1][0]) * k2 != (coordinates[i][1] - coordinates[i - 1][1]) * k1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}