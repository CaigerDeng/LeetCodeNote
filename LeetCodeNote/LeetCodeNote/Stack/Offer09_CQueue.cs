using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 剑指 Offer 09. 用两个栈实现队列
    /// https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof/
    /// </summary>

    public class Offer09_CQueue
    {
        // method 0
        // mine
        public class CQueue_0
        {
            private Stack<int> stack1; // cache
            private Stack<int> stack2; // data

            public CQueue_0()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();

            }

            public void AppendTail(int value)
            {
                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
                stack1.Push(value);
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }

            }

            public int DeleteHead()
            {
                int res = -1;
                if (stack2.Count > 0)
                {
                    res = stack2.Pop();
                }
                return res;

            }


        }

        // method 1
        public class CQueue_1
        {
            private Stack<int> stack1; 
            private Stack<int> stack2; 

            public CQueue_1()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();

            }

            public void AppendTail(int value)
            {
                stack1.Push(value);

            }

            public int DeleteHead()
            {
                if (stack2.Count == 0)
                {
                    while (stack1.Count > 0)
                    {
                        stack2.Push(stack1.Pop());
                    }
                }
                int res = -1;
                if (stack2.Count > 0)
                {
                    res = stack2.Pop();
                }
                return res;

            }


        }



    }


}