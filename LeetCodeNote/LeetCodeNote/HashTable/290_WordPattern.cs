using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 242. 有效的字母异位词
    /// https://leetcode-cn.com/problems/valid-anagram/
    /// </summary>
    /// 
    public class Solution_290_WordPattern
    {

        // method 0
        public bool WordPattern_0(string pattern, string s)
        {
            Dictionary<string, char> s2c = new Dictionary<string, char>();
            Dictionary<char, string> c2s = new Dictionary<char, string>();
            int sLen = s.Length;
            int i = 0;
            int j = 0; // i, j 用来截取s的部分字符串
            for (int p = 0; p < pattern.Length; p++)
            {
                char ch = pattern[p];
                if (i >= sLen)
                {
                    // 此时s比pattern短，s已经走完而pattern还没走完
                    return false;
                }
                j = i;
                while (j < sLen && s[j] != ' ')
                {
                    j++;
                }
                int len = j - i; // 不用再加1，因为j此时移动到了空格上
                string str = s.Substring(i, len);
                if (s2c.ContainsKey(str) && s2c[str] != ch)
                {
                    return false;
                }
                if (c2s.ContainsKey(ch) && c2s[ch] != str)
                {
                    return false;
                }
                if (!s2c.ContainsKey(str))
                {
                    s2c.Add(str, ch);
                }
                if (!c2s.ContainsKey(ch))
                {
                    c2s.Add(ch, str);
                }
                i = j + 1;
            }
            // 此时pattern走完,判断s是否走完
            return i >= sLen;

        }


    }
}