using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 389. 找不同
    /// https://leetcode-cn.com/problems/find-the-difference/
    /// </summary>

    public class Solution_389_FindTheDifference
    {
        // method 1
        // mine
        public char FindTheDifference_0(string s, string t)
        {
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
                    return c;
                }
                else
                {
                    dic[c]--;
                    if (dic[c] == 0)
                    {
                        dic.Remove(c);
                    }
                }
            }
            foreach (KeyValuePair<char, int> item in dic)
            {
                if (item.Value == 1)
                {
                    return item.Key;
                }
            }
            return ' ';

        }

        // method 1
        // 求和
        public char FindTheDifference_1(string s, string t)
        {
            int sumA = 0;
            int sumT = 0;
            foreach (char t1 in s)
            {
                sumA += t1;
            }
            foreach (char t1 in t)
            {
                sumT += t1;
            }
            return (char)(sumT - sumA);

        }

        // method 2
        // 异或位运算
        public char FindTheDifference_2(string s, string t)
        {
            int res = 0;
            foreach (char t1 in s)
            {
                res ^= t1;
            }
            foreach (char t1 in t)
            {
                res ^= t1;
            }
            return (char)res;

        }


    }


}