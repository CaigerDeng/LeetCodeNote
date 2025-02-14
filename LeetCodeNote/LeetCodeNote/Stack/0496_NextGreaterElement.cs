using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 496. 下一个更大元素 I
    /// https://leetcode-cn.com/problems/next-greater-element-i/
    /// </summary>


    public class Solution_496
    {

        // method 0
        // 单调栈，从栈顶到栈底，是单调不降（即>=）的
        public int[] NextGreaterElement_0(int[] nums1, int[] nums2)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums2.Length; i++)
            {
                int val = nums2[i];
                while (stack.Count > 0 && val > stack.Peek())
                {
                    dic.Add(stack.Pop(), val);
                }
                stack.Push(val);
            }
            while (stack.Count > 0)
            {
                dic.Add(stack.Pop(), -1);
            }
            for (int i = 0; i < nums1.Length; i++)
            {
                int k = nums1[i];
                res[i] = dic[k];
            }
            return res;

        }

    }
}