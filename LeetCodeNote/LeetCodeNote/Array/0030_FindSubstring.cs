using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 30. 串联所有单词的子串
    /// https://leetcode.cn/problems/substring-with-concatenation-of-all-words/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_30
    {

        public void Run()
        {
            //string s = "barfoothefoobarman";
            //string[] words = new string[] { "foo", "bar" };

            //string s = "wordgoodgoodgoodbestword";
            //string[] words = new string[] { "word", "good", "best", "word" };

            string s = "barfoofoobarthefoobarman";
            string[] words = new string[] { "bar", "foo", "the" };

            //string s = "wordgoodgoodgoodbestword";
            //string[] words = new string[] { "word", "good", "best", "good" };


            List<int> resList = (List<int>)FindSubstring_My_0(s, words);
            Program.PrintList(resList);


        }

        // (2025/2/9) method My 0-我的题解0
        // 在s上移动，不停遍历words看是不是串联子串
        // 错误！
        public IList<int> FindSubstring_My_0(string s, string[] words)
        {
            int oneWordLen = words[0].Length;
            List<int> resList = new List<int>();
            int childStrLen = oneWordLen * words.Length;
            if (s.Length < childStrLen)
            {
                return resList;
            }
            List<string> wordList = words.ToList();
            List<string> wordListUsed = new List<string>();
            int step = 0;
            for (int i = 0; i < s.Length;)
            {
                if (i + oneWordLen > s.Length)
                {
                    break;
                }
                string checkWord = s.Substring(i, oneWordLen);
                // 考虑到有重复单词，所以无法使用词典一类
                bool isContains = wordList.Contains(checkWord);
                if (isContains)
                {
                    wordList.Remove(checkWord);
                    wordListUsed.Add(checkWord);
                    step = oneWordLen;
                }
                else
                {
                    // 有两种可能，一种可能是words本就没有checkWord，另一种可能是words有checkWord，但恰好被wordList删去了
                    bool isUsed = wordListUsed.Contains(checkWord);
                    // 问题出现：如果isUsed为真，我不知道应该回退多少步长
                    step = isUsed ? -oneWordLen : 1;
                    wordList = words.ToList();
                    wordListUsed.Clear();
                }
                if (wordList.Count == 0)
                {
                    wordList = words.ToList();
                    wordListUsed.Clear();
                    int start = i - (words.Length - 1) * oneWordLen;
                    resList.Add(start);
                    // 成功，回退到这一个串联子串的第二个单词
                    i = start + oneWordLen;
                    step = 0;
                }
                i += step;
            }
            return resList;

        }



    }

}
