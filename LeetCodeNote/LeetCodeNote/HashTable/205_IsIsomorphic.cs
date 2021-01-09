using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 205. 同构字符串
    /// https://leetcode-cn.com/problems/isomorphic-strings/
    /// </summary>


    public class Solution_205_IsIsomorphic
    {
        // method 0
        public bool IsIsomorphic_0(string s, string t)
        {
            Dictionary<char, char> s2t = new Dictionary<char, char>();
            Dictionary<char, char> t2s = new Dictionary<char, char>();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char x = s[i];
                char y = t[i];
                if (s2t.ContainsKey(x) && s2t[x] != y || t2s.ContainsKey(y) && t2s[y] != x)
                {
                    return false;
                }
                if (!s2t.ContainsKey(x))
                {
                    s2t.Add(x, y);
                }
                if (!t2s.ContainsKey(y))
                {
                    t2s.Add(y, x);
                }
            }
            return true;

        }

    }
}