using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 205. 同构字符串（举例：一个词是AAB形式，判断另一个词是否也是这种形式）
    /// https://leetcode.cn/problems/isomorphic-strings/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_205
    {
        public void Run()
        {
            //string s = "egg";
            //string t = "add"; // res:true

            //string s = "foo";
            //string t = "bar"; // res:false

            //string s = "paper";
            //string t = "title"; // res:true

            //string s = "bbbaaaba";
            //string t = "aaabbbba"; 

            string s = "abcdefghijklmnopqrstuvwxyzva";
            string t = "abcdefghijklmnopqrstuvwxyzck"; // res:false



            bool res = IsIsomorphic_My_0(s, t);
            Console.WriteLine("res:{0}", res);

        }

        // (2025/2/14) method My 0-我的题解0
        // 按题意直写，用词典记录形式做判断
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool IsIsomorphic_My_0(string s, string t)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                int v;
                if (dic.ContainsKey(c))
                {
                    v = dic[c];
                }
                else
                {
                    v = dic.Count;
                    dic.Add(c, v);
                }
                sb.Append(v.ToString() + "_");
            }
            string sStr = sb.ToString();
            sb.Clear();
            dic.Clear();
            
            foreach (char c in t)
            {
                int v;
                if (dic.ContainsKey(c))
                {
                    v = dic[c];
                }
                else
                {
                    v = dic.Count;
                    dic.Add(c, v);
                }
                sb.Append(v.ToString() + "_");
            }
            string tStr = sb.ToString();
            sb.Clear();
            dic.Clear();

            return sStr == tStr;

        }

        // method 1-官方题解1
        // 用两个词典来做双向映射
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool IsIsomorphic_0(string s, string t)
        {
            Dictionary<char, char> s2t = new Dictionary<char, char>();
            Dictionary<char, char> t2s = new Dictionary<char, char>();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char x = s[i];
                char y = t[i];
                if ((s2t.ContainsKey(x) && s2t[x] != y) || (t2s.ContainsKey(y) && t2s[y] != x))
                {
                    return false;
                }
                s2t.TryAdd(x, y);
                t2s.TryAdd(y, x);
            }
            return true;

        }

    }
}