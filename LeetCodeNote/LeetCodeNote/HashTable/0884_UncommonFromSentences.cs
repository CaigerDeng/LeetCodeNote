using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 884. 两句话中的不常见单词
    /// https://leetcode-cn.com/problems/uncommon-words-from-two-sentences/
    /// </summary>


    public class Solution_884_UncommonFromSentences
    {
        // method 0
        public string[] UncommonFromSentences(string A, string B)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word in A.Split(' '))
            {
                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, 0);
                }
                dic[word]++;
            }
            foreach (string word in B.Split(' '))
            {
                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, 0);
                }
                dic[word]++;
            }
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, int> pair in dic)
            {
                if (pair.Value == 1)
                {
                    list.Add(pair.Key);
                }
            }
            return list.ToArray();

        }

    }

}