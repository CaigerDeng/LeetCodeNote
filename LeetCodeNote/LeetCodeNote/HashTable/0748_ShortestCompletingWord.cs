using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 748. 最短补全词
    /// https://leetcode-cn.com/problems/shortest-completing-word/
    /// </summary>


    public class Solution_748_ShortestCompletingWord
    {
        // method 0
        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            string res = "";
            Dictionary<char, int> sourceDic = GetDic(licensePlate);
            foreach (string word in words)
            {
                if ((res.Length == 0 || word.Length < res.Length) && Check(sourceDic, GetDic(word.ToLower())))
                {
                    res = word;
                }
            }
            return res;

        }

        public bool Check(Dictionary<char, int> sourceDic, Dictionary<char, int> dic)
        {
            foreach (char key in sourceDic.Keys)
            {
                if (!dic.ContainsKey(key) || dic[key] < sourceDic[key])
                {
                    return false;
                }
            }
            return true;

        }

        public Dictionary<char, int> GetDic(string word)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    char ch = char.ToLower(c);
                    if (!dic.ContainsKey(ch))
                    {
                        dic.Add(ch, 0);
                    }
                    dic[ch]++;
                }
            }
            return dic;

        }



    }

}