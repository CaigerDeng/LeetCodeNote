using System;
using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 225. 用队列实现栈
    /// https://leetcode-cn.com/problems/implement-stack-using-queues/
    /// </summary>

    public class Solution_225_MyStack
    {
        // method 0
        public class MyStack
        {
            private Queue<int> queue1 = null; // 存数据用
            private Queue<int> queue2 = null; // 数据中转站

            /** Initialize your data structure here. */
            public MyStack()
            {
                queue1 = new Queue<int>();
                queue2 = new Queue<int>();

            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                queue2.Enqueue(x);
                while (queue1.Count > 0)
                {
                    int val = queue1.Dequeue();
                    queue2.Enqueue(val);
                }
                var temp = queue2;
                queue2 = queue1;
                queue1 = temp;
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return queue1.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return queue1.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return queue1.Count == 0;
            }


        }



    }


}