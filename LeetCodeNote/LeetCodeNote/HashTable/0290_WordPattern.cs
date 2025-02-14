using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 290. 单词规律
    /// https://leetcode.cn/problems/word-pattern/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_290
    {
        public void Run()
        {
            //string pattern = "abba";
            //string s = "dog cat cat dog"; // res: true

            //string pattern = "abba";
            //string s = "dog cat cat fish"; // res:false

            string pattern = "aaa";
            string s = "aa aa aa aa"; // res:false


            bool res = WordPattern_My_0(pattern, s);
            Console.WriteLine("res:{0}", res);

        }

        // (2025/2/14) method My 0-我的题解0
        // 按题意直写，为了双向映射而准备两个词典
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool WordPattern_My_0(string pattern, string s)
        {
            Dictionary<char, string> p2s = new Dictionary<char, string>();
            Dictionary<string, char> s2p = new Dictionary<string, char>();
            string[] wordArr = s.Split(' ');
            if (pattern.Length != wordArr.Length)
            {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                char x = pattern[i];
                string y = wordArr[i];
                if ((p2s.ContainsKey(x) && p2s[x] != y) || (s2p.ContainsKey(y) && s2p[y] != x))
                {
                    // 双向映射 对不上
                    return false;
                }
                p2s.TryAdd(x, y);
                s2p.TryAdd(y, x);
            }
            return true;

        }

        // method 1-官方题解1
        // 思路和“我的题解0”一样
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool WordPattern_1(string pattern, string s)
        {
            Dictionary<string, char> s2c = new Dictionary<string, char>();
            Dictionary<char, string> c2s = new Dictionary<char, string>();
            int sLen = s.Length;
            // i, j 用来截取s的部分字符串
            int i = 0;
            int j = 0;
            for (int p = 0; p < pattern.Length; p++)
            {
                char ch = pattern[p];
                if (i >= sLen)
                {
                    // 如果s比pattern短
                    return false;
                }
                j = i;
                while (j < sLen && s[j] != ' ')
                {
                    j++;
                }
                string str = s.Substring(i, j - i);
                if (s2c.ContainsKey(str) && s2c[str] != ch)
                {
                    return false;
                }
                if (c2s.ContainsKey(ch) && c2s[ch] != str)
                {
                    return false;
                }
                s2c.TryAdd(str, ch);
                c2s.TryAdd(ch, str);
                i = j + 1;
            }
            // 此时pattern走完，理论上在s中，j已经走到了sLen这个索引，则i为sLen+1
            // 考虑到还有s比pattern长的情况，不能直接return true
            return i > sLen;

        }


    }
}