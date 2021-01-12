using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 242. 有效的字母异位词
    /// https://leetcode-cn.com/problems/valid-anagram/
    /// </summary>


    public class Solution_242_IsAnagram
    {
        // method 0
        public bool IsAnagram_0(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            char[] str1 = s.ToCharArray();
            char[] str2 = t.ToCharArray();
            System.Array.Sort(str1);
            System.Array.Sort(str2);
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;

        }

        // method 1
        public bool IsAnagram_1(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] arr = new int[26];
            foreach (char c in s)
            {
                //int index = c - 'a';
                //Console.WriteLine("index: ", index);
                arr[c - 'a']++;
            }
            foreach (char c in t)
            {
                arr[c - 'a']--;
                if (arr[c - 'a'] < 0)
                {
                    // 说明t有不同于s的字符出现
                    return false;
                }
            }
            return true;

        }

        // method 2
        // 考虑到字符串可能是各种语言， method 1的改进
        public bool IsAnagram_2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 0);
                }
                dic[c]++;
            }
            foreach (char c in t)
            {
                if (!dic.ContainsKey(c))
                {
                    return false;
                }
                dic[c]--;
                if (dic[c] < 0)
                {
                    return false;
                }
            }
            return true;

        }


    }

}