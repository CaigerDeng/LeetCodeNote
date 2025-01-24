using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 68. 文本左右对齐
    /// https://leetcode.cn/problems/text-justification/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_68
    {
        public void Run()
        {

            string[] words = { "This", "is", "an", "example", "of", "text", "justification." };
            int maxWidth = 16;

            //string[] words = { "What", "must", "be", "acknowledgment", "shall", "be" };
            //int maxWidth = 16;

            //string[] words = { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
            //int maxWidth = 20;


            List<string> res = (List<string>)FullJustify_My_0(words, maxWidth);


            PrintList(res);


        }

        private void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();

        }


        // 我的题解0，没有特别算法，按题意直写
        // 时间复杂度：O(n)，空间复杂度：O(n)
        public IList<string> FullJustify_My_0(string[] words, int maxWidth)
        {
            //////////// 1. 收集id
            List<string> res = new List<string>();
            List<List<int>> idPerLineList = new List<List<int>>();
            int currLineIndex = 0;
            int w = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    List<int> list = new List<int>();
                    idPerLineList.Add(list);
                }
                if (w + words[i].Length > maxWidth)
                {
                    currLineIndex++;
                    List<int> list = new List<int>();
                    idPerLineList.Add(list);
                    w = 0;
                }
                idPerLineList[currLineIndex].Add(i);
                w += words[i].Length + 1;
            }
            //////////// 2. 修饰空格
            int lineNum = idPerLineList.Count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lineNum; i++)
            {
                sb.Clear();
                if (i != lineNum - 1)
                {
                    // fixStrLen包含必要空格
                    int fixStrLen = idPerLineList[i].Count - 1;
                    for (int j = 0; j < idPerLineList[i].Count; j++)
                    {
                        int id = idPerLineList[i][j];
                        string str = words[id];
                        fixStrLen += str.Length;
                    }
                    // 平均每个间隔需要多少修饰空格
                    // （看了官方题解再看我算空格的这段，确实有点停止思考的感觉...）
                    int decSpaceNum = maxWidth - fixStrLen;
                    int[] arr;
                    int n = decSpaceNum;
                    int a = 0;
                    if (idPerLineList[i].Count == 1)
                    {
                        // 如果一行只有一个单词
                        int id = idPerLineList[i][0];
                        string str = words[id];
                        sb.Append(str);
                        while (sb.Length < maxWidth)
                        {
                            sb.Append(" ");
                        }
                    }
                    else
                    {
                        arr = new int[idPerLineList[i].Count - 1];
                        // 从左往右分发修饰空格，能保证左边>=右边
                        while (n > 0)
                        {
                            arr[a] += 1;
                            n--;
                            a = (a + 1) % arr.Length;
                        }
                        a = 0;
                        for (int j = 0; j < idPerLineList[i].Count; j++)
                        {
                            int id = idPerLineList[i][j];
                            string str = words[id];
                            sb.Append(str);
                            if (j != idPerLineList[i].Count - 1)
                            {
                                sb.Append(" ");
                                if (a >= arr.Length)
                                {
                                    Console.WriteLine("Weird!");
                                }
                                for (int k = 0; k < arr[a]; k++)
                                {
                                    sb.Append(" ");
                                }
                                a++;
                            }
                        }
                    }
                }
                else
                {
                    // 最后一行只用左对齐
                    for (int j = 0; j < idPerLineList[i].Count; j++)
                    {
                        int id = idPerLineList[i][j];
                        string str = words[id];
                        sb.Append(str);
                        if (j != idPerLineList[i].Count - 1)
                        {
                            sb.Append(" ");
                        }
                    }
                    // 最后一行如果不够仍需填满
                    while (sb.Length < maxWidth)
                    {
                        sb.Append(" ");
                    }
                }
                res.Add(sb.ToString());
            }

            return res;

        }

        // method 1-官方题解1
        // 和“我的题解0”思路一样，不过官方写得比我好，更简洁，它优化了收集索引
        public IList<string> FullJustify_1(string[] words, int maxWidth)
        {
            List<string> res = new List<string>();
            // 当前行 第一个单词的索引
            int left = 0;
            // 当前行 当前单词的索引
            int right = 0;
            int n = words.Length;
            while (true)
            {
                left = right;
                // 统计这一行单词长度之和
                int sumLen = 0;
                //  right - left指单词之间的必要空格数量
                while (right < n && sumLen + words[right].Length + right - left <= maxWidth)
                {
                    sumLen += words[right++].Length;
                }

                // 当前行是最后一行：单词左对齐，且单词之间应只有一个空格，在行末填充剩余空格
                if (right == n)
                {
                    StringBuilder sb = Join(words, left, n, " ");
                    sb.Append(Blank(maxWidth - sb.Length));
                    res.Add(sb.ToString());
                    return res;
                }

                int numWords = right - left;
                int numSpaces = maxWidth - sumLen;
                // 当前行只有一个单词：该单词左对齐，在行末填充剩余空格
                if (numWords == 1)
                {
                    StringBuilder sb = new StringBuilder(words[left]);
                    sb.Append(Blank(numSpaces));
                    res.Add(sb.ToString());
                    continue;
                }

                // 当前行不只一个单词
                int avgSpaces = numSpaces / (numWords - 1);
                int extraSpaces = numSpaces % (numWords - 1);
                StringBuilder curr = new StringBuilder();
                // 要加额外空格的有extraSpaces个单词，一个间隔要加avgSpaces + 1个空格
                curr.Append(Join(words, left, left + extraSpaces + 1, Blank(avgSpaces + 1)));
                curr.Append(Blank(avgSpaces));
                // 剩下单词都是加平均空格
                curr.Append(Join(words, left + extraSpaces + 1, right, Blank(avgSpaces)));
                res.Add(curr.ToString());
            }

        }

        // 加n个空格
        private string Blank(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; ++i)
            {
                sb.Append(' ');
            }
            return sb.ToString();

        }


        private StringBuilder Join(string[] words, int left, int right, string sep)
        {
            StringBuilder sb = new StringBuilder(words[left]);
            for (int i = left + 1; i < right; i++)
            {
                sb.Append(sep);
                sb.Append(words[i]);
            }
            return sb;

        }


    }

}
