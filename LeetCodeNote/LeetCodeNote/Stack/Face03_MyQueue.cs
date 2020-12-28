using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    public class Face03_MyQueue
    {

        /// <summary>
        /// 面试题 03.04. 化栈为队
        /// https://leetcode-cn.com/problems/implement-queue-using-stacks-lcci/
        /// </summary>

        public class MyQueue
        {
            private Stack<int> stack0;
            private Stack<int> stack1;
            private int front;

            /** Initialize your data structure here. */
            public MyQueue()
            {
                stack0 = new Stack<int>();
                stack1 = new Stack<int>();

            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                if (stack0.Count == 0)
                {
                    front = x;
                }
                stack0.Push(x);

            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (stack1.Count == 0)
                {
                    while (stack0.Count > 0)
                    {
                        stack1.Push(stack0.Pop());
                    }
                }
                return stack1.Pop();

            }

            /** Get the front element. */
            public int Peek()
            {
                if (stack1.Count > 0)
                {
                    return stack1.Peek();
                }
                return front;

            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return stack0.Count == 0 && stack1.Count == 0;

            }
        }

        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */

    }
}