using System.Collections.Generic;

namespace LeetCodeNote.Queue
{
    /// <summary>
    /// 933. 最近的请求次数
    /// https://leetcode-cn.com/problems/number-of-recent-calls/
    /// </summary>


    public class Solution_933_RecentCounter
    {
        // method 0
        public class RecentCounter
        {
            private Queue<int> queue = null;

            public RecentCounter()
            {
                queue = new Queue<int>();

            }

            public int Ping(int t)
            {
                queue.Enqueue(t);
                while (queue.Peek() < t - 3000)
                {
                    queue.Dequeue();
                }
                return queue.Count;

            }

        }



    }
}