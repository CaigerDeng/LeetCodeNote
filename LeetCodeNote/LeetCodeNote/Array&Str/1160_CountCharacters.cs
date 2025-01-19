using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1160. 拼写单词
    /// https://leetcode-cn.com/problems/find-words-that-can-be-formed-by-characters/
    /// </summary>

    public class Solution_1160
    {

        // method 0
        public int CountCharacters_0(string[] words, string chars)
        {
            Dictionary<char, int> charsDic = new Dictionary<char, int>();
            foreach (var c in chars)
            {
                if (!charsDic.ContainsKey(c))
                {
                    charsDic[c] = 0;
                }
                charsDic[c]++;
            }
            int res = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                Dictionary<char, int> dic = new Dictionary<char, int>();
                foreach (char c in word)
                {
                    if (!dic.ContainsKey(c))
                    {
                        dic[c] = 0;
                    }
                    dic[c]++;
                }
                bool hasWord = true;
                foreach (char k in dic.Keys)
                {
                    if (!charsDic.ContainsKey(k) || charsDic[k] < dic[k])
                    {
                        hasWord = false;
                        break;
                    }
                }
                if (hasWord)
                {
                    res += word.Length;
                }
            }
            return res;

        }



    }


}