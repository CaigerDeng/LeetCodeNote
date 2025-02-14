using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 387. 字符串中的第一个唯一字符
    /// https://leetcode-cn.com/problems/first-unique-character-in-a-string/
    /// </summary>

    public class Solution_387_FirstUniqChar
    {
        // method 0
        public int FirstUniqChar_0(string s)
        {
            Dictionary<char, int> freDic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!freDic.ContainsKey(c))
                {
                    freDic.Add(c, 0);
                }
                freDic[c]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (freDic[c] == 1)
                {
                    return i;
                }
            }
            return -1;

        }

        // method 1
        public int FirstUniqChar_1(string s)
        {
            Dictionary<char, int> posDic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!posDic.ContainsKey(c))
                {
                    posDic.Add(c, i);
                }
                else
                {
                    posDic[c] = -1;
                }
            }
            foreach (int pos in posDic.Values)
            {
                if (pos != -1)
                {
                    return pos;
                }
            }
            return -1;

        }

        // method 2
        // method 1后半截另一种写法
        public int FirstUniqChar_2(string s)
        {
            Dictionary<char, int> posDic = new Dictionary<char, int>();
            Queue<Pair> queue = new Queue<Pair>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!posDic.ContainsKey(c))
                {
                    posDic.Add(c, i);
                    Pair p = new Pair(c, i);
                    queue.Enqueue(p);
                }
                else
                {
                    posDic[c] = -1;
                    while (queue.Count > 0 && posDic[queue.Peek().c] == -1)
                    {
                        queue.Dequeue();
                    }
                }
            }
            return queue.Count > 0 ? queue.Peek().index : -1;

        }

        private class Pair
        {
            public char c;
            public int index = -1;

            public Pair(char c, int index)
            {
                this.c = c;
                this.index = index;

            }


        }


    }

}