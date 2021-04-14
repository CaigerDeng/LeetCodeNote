using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 1078. Bigram 分词
    /// https://leetcode-cn.com/problems/occurrences-after-bigram/
    /// </summary>


    public class Solution_1078_FindOcurrences
    {
        // method 0
        public string[] FindOcurrences_0(string text, string first, string second)
        {
            List<string> res = new List<string>();
            string[] textStr = text.Split(' ');
            for (int i = 0; i < textStr.Length - 2; i++)
            {
                if (textStr[i] == first && textStr[i + 1] == second)
                {
                    res.Add(textStr[i + 2]);
                }
            }
            return res.ToArray();

        }

    }

}