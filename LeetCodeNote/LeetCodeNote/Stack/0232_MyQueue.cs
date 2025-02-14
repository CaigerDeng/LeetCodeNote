using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 232. 用栈实现队列
    /// https://leetcode-cn.com/problems/implement-queue-using-stacks/
    /// </summary>

    public class Solution_232_MyQueue
    {
        // method 0
        public class MyQueue
        {
            private Stack<int> stack1 = null; // 存数据用
            private Stack<int> stack2 = null; // 数据中转站

            /** Initialize your data structure here. */
            public MyQueue()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                while (stack1.Count > 0)
                {
                    int val = stack1.Pop();
                    stack2.Push(val);
                }
                stack2.Push(x);
                while (stack2.Count > 0)
                {
                    int val = stack2.Pop();
                    stack1.Push(val);
                }
                
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return stack1.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return stack1.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return stack1.Count == 0;
            }

        }



    }


}