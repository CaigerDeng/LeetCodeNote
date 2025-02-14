using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 242. 有效的字母异位词
    /// https://leetcode.cn/problems/valid-anagram/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_242
    {
        public void Run()
        {
            string s = "anagram";
            string t = "nagaram"; // res:true 


            bool res = IsAnagram_1(s, t);
            Console.WriteLine("res:{0}", res);

        }

        // (2025/2/14) method My 0-我的题解0
        // 按题意直写，用词典.
        // 也适用“输入字符串包含 unicode 字符”的情况
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool IsAnagram_My_0(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                dic.TryAdd(c, 0);
                dic[c]++;
            }
            foreach (char c in t)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]--;
                    if (dic[c] < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        // method 1-官方题解1
        // 所有字母排序
        // 没有考虑“输入字符串包含 unicode 字符”的情况
        // 时间复杂度：O(NlogN)(针对排序)，空间复杂度：O(logN)(针对排序)
        public bool IsAnagram_1(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            char[] str1 = s.ToCharArray();
            char[] str2 = t.ToCharArray();
            System.Array.Sort(str1);
            System.Array.Sort(str2);
            // 写str1 == str2是不对的
            return str1.SequenceEqual(str2);

        }

        // method 2_0-官方题解2
        // 和“我的题解0”思路一样，只是官方用的是记了26个字母的数组
        // 没有考虑“输入字符串包含 unicode 字符”的情况
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool IsAnagram_2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] arr = new int[26];
            foreach (char c in s)
            {
                arr[c - 'a']++;
            }
            foreach (char c in t)
            {
                arr[c - 'a']--;
                if (arr[c - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;

        }

        // method 2_1-官方题解2的优化，考虑了unicode的情况
        // 和“我的题解0”完全一样
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool IsAnagram_3(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                dic.TryAdd(c, 0);
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