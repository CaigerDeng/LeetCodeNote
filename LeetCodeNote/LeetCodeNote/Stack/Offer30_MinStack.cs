using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 155. 最小栈
    /// https://leetcode-cn.com/problems/min-stack/
    /// </summary>

    public class Offer30_MinStack
    {
        // mine
        public class MinStack
        {
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

            public int Min()
            {
                return min;
            }

        }




    }

}