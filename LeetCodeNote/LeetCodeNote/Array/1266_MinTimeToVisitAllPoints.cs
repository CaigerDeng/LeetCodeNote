using System;
using System.Runtime.CompilerServices;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1266. 访问所有点的最小时间
    /// https://leetcode-cn.com/problems/minimum-time-visiting-all-points/
    /// </summary>

    public class Solution_1266
    {
        // method 0
        // 要求斜率是固定的
        public int MinTimeToVisitAllPoints_0(int[][] points)
        {
            int x0 = points[0][0];
            int y0 = points[0][1];
            int time = 0;
            for (int i = 1; i < points.Length; i++)
            {
                int x1 = points[i][0];
                int y1 = points[i][1];
                int dx = Math.Abs(x1 - x0);
                int dy = Math.Abs(y1 - y0);
                time += Math.Max(dx, dy);
                x0 = x1;
                y0 = y1;
            }
            return time;
        }



    }
}