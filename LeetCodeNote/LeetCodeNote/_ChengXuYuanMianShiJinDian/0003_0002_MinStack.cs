using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote._ChengXuYuanMianShiJinDian
{
    /// <summary>
    /// 面试题 03.02. 栈的最小值
    /// https://leetcode-cn.com/problems/min-stack-lcci/
    /// </summary>


    public class Solution_CYX_03_02
    {
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

            public int GetMin()
            {
                return min;
            }
        }


    }
}