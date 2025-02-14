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

            string s = "wordgoodgoodgoodbestword";
            string[] words = new string[] { "word", "good", "best", "word" };

            //string s = "barfoofoobarthefoobarman";
            //string[] words = new string[] { "bar", "foo", "the" };

            //string s = "wordgoodgoodgoodbestword";
            //string[] words = new string[] { "word", "good", "best", "good" };


            List<int> resList = (List<int>)FindSubstring_1(s, words);
            Program.PrintList(resList);


        }

        // (2025/2/9) method My 0-我的题解0
        // 在s上移动，不停遍历words看是不是串联子串
        // 错误！思路有“官方题解1”的影子，可以直接看“官方题解1”
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
                    // 【？？？】问题出现：如果isUsed为真，我不知道应该回退多少步长
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

        // (2025/2/10) method My 1-我的题解1
        // 全排列写法
        // 超出时限！（意料之中）
        public IList<int> FindSubstring_My_1(string s, string[] words)
        {
            int oneWordLen = words[0].Length;
            List<int> resList = new List<int>();
            int childStrLen = oneWordLen * words.Length;
            if (s.Length < childStrLen)
            {
                return resList;
            }
            List<string> allChildStrList = GetConcatenatedSubstrings(words);
            for (int i = 0; i < s.Length; i++)
            {
                if (i + childStrLen > s.Length)
                {
                    break;
                }
                string checkChild = s.Substring(i, childStrLen);
                if (allChildStrList.Contains(checkChild))
                {
                    resList.Add(i);
                }
            }
            return resList;

        }

        private List<string> GetConcatenatedSubstrings(string[] words)
        {
            List<string> result = new List<string>();
            GetPermutations(words, result, "", new bool[words.Length]);
            return result;

        }

        // 求全排列
        private void GetPermutations(string[] words, List<string> result, string current, bool[] used)
        {
            if (current.Length == words.Length * words[0].Length)
            {
                result.Add(current);
                return;
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    GetPermutations(words, result, current + words[i], used);
                    used[i] = false;
                }
            }

        }

        // method 1-官方题解1
        // 滑动窗口
        // 时间复杂度：O(ls×n)，空间复杂度：O(m×n)
        public IList<int> FindSubstring_1(string s, string[] words)
        {
            List<int> resList = new List<int>();
            int m = words.Length;
            int n = words[0].Length;
            int ls = s.Length;
            // 将s划分为单词组，每个单词大小为n。这种划分方法有n种，即先删去前i个字母后再划分
            for (int i = 0; i < n; i++)
            {
                // m * n为串联子串长度
                if (i + m * n > ls)
                {
                    // 此时s的剩下长度已经不够一个串联子串
                    break;
                }
                // 准备滑动窗口，窗口有m个单词
                // 准备differ，differ记录为该窗口与words的差异
                // differ初始值为窗口不移动时的数据
                Dictionary<string, int> differ = new Dictionary<string, int>();
                for (int j = 0; j < m; j++)
                {
                    // 这里s按一个一个单词的步长走，i只是起点，窗口有m个单词
                    string word = s.Substring(i + j * n, n);
                    differ.TryAdd(word, 0);
                    differ[word]++;
                }
                foreach (string word in words)
                {
                    differ.TryAdd(word, 0);
                    // 也就是说记录可能有负数出现
                    differ[word]--;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                }
                // 滑动 滑动窗口，窗口一个单词一个单词的滑动
                for (int start = i; start < ls - m * n + 1; start += n)
                {
                    // 因为前面differ初始值为窗口不移动时的数据，所以start不能从i开始
                    if (start != i)
                    {
                        // 因为窗口往右滑动了，为了保证窗口大小不变，所以需要加上一个右侧单词
                        string word = s.Substring(start + (m - 1) * n, n);
                        differ.TryAdd(word, 0);
                        differ[word]++;
                        // 因为不知道word是什么，所以随时检查differ很有必要，这里的remove不能删
                        if (differ[word] == 0)
                        {
                            differ.Remove(word);
                        }
                        // 因为窗口往右滑动了，为了保证窗口大小不变，所以需要移除一个左侧单词
                        word = s.Substring(start - n, n);
                        differ.TryAdd(word, 0);
                        differ[word]--;
                        // 因为不知道word是什么，所以随时检查differ很有必要，这里的remove不能删
                        if (differ[word] == 0)
                        {
                            differ.Remove(word);
                        }
                    }
                    // 如果完全没有差异，说明串联子串出现
                    if (differ.Count == 0)
                    {
                        resList.Add(start);
                    }
                }
            }
            return resList;

        }



    }

}
