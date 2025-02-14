using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 155. 最小栈
    /// https://leetcode-cn.com/problems/min-stack/
    /// </summary>

    public class Solution_155_MinStack
    {
        // mine
        // 官方题解用的是两个栈，一个记录数据，一个记录最小值
        public class MinStack
        {
            /** initialize your data structure here. */
            private List<int> list = null;
            private int min = int.MaxValue;

            public MinStack()
            {
                list = new List<int>();
            }

            public void Push(int x)
            {
                list.Add(x);
                if (x < min)
                {
                    min = x;
                }
            }

            public void Pop()
            {
                list.RemoveAt(list.Count - 1);
                if (list.Count > 0)
                {
                    min = list.Min();
                }
                else
                {
                    min = int.MaxValue;
                }

            }

            public int Top()
            {
                return list[list.Count - 1];
            }

            public int GetMin()
            {
                return min;
            }

        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */


    }
}