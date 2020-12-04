using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.Stack
{

    /// <summary>
    /// 1021. 删除最外层的括号
    /// https://leetcode-cn.com/problems/remove-outermost-parentheses/
    /// </summary>


    public class Solution_1021
    {

        // method 0
        public string RemoveOuterParentheses_0(string S)
        {
            Stack<int> stack = new Stack<int>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                int left = i;
                if (S[i] == '(')
                {
                    // 记录的是索引
                    stack.Push(i);
                }
                else
                {
                    left = stack.Pop();
                }
                if (stack.Count == 0 && i - left - 1 > 0)
                {
                    sb.Append(S.Substring(left + 1, i - left - 1));
                }
            }
            return sb.ToString();

        }


    }
}