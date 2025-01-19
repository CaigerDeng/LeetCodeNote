using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1184. 公交站间的距离
    /// https://leetcode-cn.com/problems/distance-between-bus-stops/
    /// </summary>


    public class Solution_1184
    {
        // method 0
        public int DistanceBetweenBusStops_0(int[] distance, int start, int destination)
        {
            int sum = 0;
            int dis = 0;
            for (int i = 0; i < distance.Length; i++)
            {
                sum += distance[i];
                if (i >= Math.Min(start, destination) && i < Math.Max(start, destination))
                {
                    dis += distance[i];
                }
            }
            return Math.Min(dis, sum - dis);
        }



    }
}