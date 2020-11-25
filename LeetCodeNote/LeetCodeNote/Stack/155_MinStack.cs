using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Stack
{
    public class Solution_155_MinStack
    {
        // 官方题解用的是两个栈，一个记录数据，一个记录最小值
        // 我用数组，方法里故意没做检测，却无法通过，但我不认为我是错的……
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
                min = list.Min();

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