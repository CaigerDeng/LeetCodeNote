using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1560. 圆形赛道上经过次数最多的扇区
    /// https://leetcode-cn.com/problems/most-visited-sector-in-a-circular-track/
    /// </summary>


    public class Solution_1560
    {
        // method 0
        public IList<int> MostVisited_0(int n, int[] rounds)
        {
            List<int> res = new List<int>();
            int start = rounds[0];
            int end = rounds[rounds.Length - 1];
            if (start <= end)
            {
                for (int i = start; i <= end; i++)
                {
                    res.Add(i);
                }
            }
            else
            {
                // 题目要求“按扇区编号升序排列”
                for (int i = 1; i <= end; i++)
                {
                    res.Add(i);
                }
                for (int i = start; i <= n; i++)
                {
                    res.Add(i);
                }
            }
            return res;

        }


    }
}