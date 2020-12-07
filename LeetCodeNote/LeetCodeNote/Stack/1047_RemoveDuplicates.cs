using System;
using System.Collections.Generic;
using System.Text;


namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 1047. 删除字符串中的所有相邻重复项
    /// https://leetcode-cn.com/problems/remove-all-adjacent-duplicates-in-string/
    /// </summary>

    public class Solution_1047
    {
        // method 1
        public string RemoveDuplicates_1(string S)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in S)
            {
                if (sb.Length > 0 && c == sb[sb.Length - 1])
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();

        }

        // method 0
        public string RemoveDuplicates_0(string S)
        {
            HashSet<string> duplicates = new HashSet<string>();
            StringBuilder sb = new StringBuilder();
            for (char i = 'a'; i <= 'z'; i++)
            {
                sb.Clear();
                sb.Append(i);
                sb.Append(i);
                duplicates.Add(sb.ToString());
            }
            int prevLen = -1;
            while (prevLen != S.Length)
            {
                prevLen = S.Length;
                foreach (string d in duplicates)
                {
                    S = S.Replace(d, "");
                }
            }
            return S;

        }

    }
}