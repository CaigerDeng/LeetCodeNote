using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 1441. 用栈操作构建数组
    /// https://leetcode-cn.com/problems/build-an-array-with-stack-operations/
    /// </summary>


    public class Solution_1441
    {
        // method 0
        // mine
        // ...测试用例有问题
        public IList<string> BuildArray_0(int[] target, int n)
        {
            List<string> list = new List<string>();
            int index = 0;
            for (int i = 1; i <= n; i++)
            {
                int val = target[index];
                list.Add("Push");
                if (i < val)
                {
                    list.Add("Pop");
                    index--;
                }               
                index++;
                if (index > target.Length - 1)
                {
                    break;
                }
            }
            return list;

        }


    }
}