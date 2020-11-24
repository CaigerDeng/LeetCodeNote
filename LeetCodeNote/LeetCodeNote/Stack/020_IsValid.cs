using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 20. 有效的括号
    /// https://leetcode-cn.com/problems/valid-parentheses/
    /// </summary>

    public class Solution_020
    {

        // method 0
        public bool IsValid_0(string s)
        {
            int len = s.Length;
            if (len % 2 == 1)
            {
                return false;
            }
            Dictionary<char, char> dic = new Dictionary<char, char>();
            dic.Add(')', '(');
            dic.Add(']', '[');
            dic.Add('}', '{');
            Stack<char> stack = new Stack<char>();
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                if (dic.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Peek() != dic[c])
                    {
                        return false;
                    }
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;

        }


    }
}