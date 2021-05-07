using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{

    /// <summary>
    /// 1748. 唯一元素的和
    /// https://leetcode-cn.com/problems/sum-of-unique-elements/
    /// </summary>


    public class Solution_Offer50_FirstUniqChar
    {
        // method 0
        public char FirstUniqChar_0(string s)
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
            foreach (char ch in s)
            {
                if (dic[ch] == 1)
                {
                    return ch;
                }
            }
            return ' ';

        }

        // method 1
        // 和method 0意思差不多
        public char FirstUniqChar_1(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (dic.ContainsKey(ch))
                {
                    dic[ch] = -1;
                }
                else
                {
                    dic.Add(ch, i);
                }
            }
            int first = s.Length;
            foreach (int v in dic.Values)
            {
                if (v != -1 && v < first)
                {
                    first = v;
                }
            }
            return first == s.Length ? ' ' : s[first];

        }

        // method 2
        public char FirstUniqChar_2(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            Queue<Pair> queue = new Queue<Pair>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (dic.ContainsKey(ch))
                {
                    dic[ch] = -1;
                    // 停在首次出现不重复元素这里
                    while (queue.Count > 0 && dic[queue.Peek().ch] == -1)
                    {
                        queue.Dequeue();
                    }
                }
                else
                {
                    dic.Add(ch, i);
                    queue.Enqueue(new Pair(ch, i));
                }
            }
            return queue.Count == 0 ? ' ' : queue.Dequeue().ch;

        }

        public class Pair
        {
            public char ch;
            public int pos;

            public Pair(char ch, int pos)
            {
                this.ch = ch;
                this.pos = pos;

            }

        }

    }
}