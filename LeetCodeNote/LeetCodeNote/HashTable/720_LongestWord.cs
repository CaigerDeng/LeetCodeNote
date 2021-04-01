using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 720. 词典中最长的单词
    /// https://leetcode-cn.com/problems/longest-word-in-dictionary/
    /// </summary>


    public class Solution_720_LongestWord
    {
        // method 0
        // 暴力法
        public string LongestWord_0(string[] words)
        {
            string res = "";
            HashSet<string> wordSet = new HashSet<string>(words);
            foreach (string word in words)
            {
                if (word.Length > res.Length || (word.Length == res.Length && word.CompareTo(res) < 0))
                {
                    bool good = true;
                    for (int i = 1; i < word.Length; i++)
                    {
                        if (!wordSet.Contains(word.Substring(0, i)))
                        {
                            good = false;
                            break;
                        }
                    }
                    if (good)
                    {
                        res = word;
                    }
                }
            }
            return res;

        }

        // method 1
        // 前缀树 + 深度优先搜索
        public string LongestWord_1(string[] words)
        {
            Trie trie = new Trie();
            int index = 0;
            foreach (string word in words)
            {
                // index从插入元素开始，从1开始数，因为0给了根节点，对应下面Dfs函数
                trie.Insert(word, ++index);
            }
            trie.words = words;
            return trie.Dfs();

        }


        public class Node
        {
            public char c;
            // 不用数组而用哈希来存
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public int end;

            public Node(char c)
            {
                this.c = c;
            }

        }

        // 前缀树
        public class Trie
        {
            public Node root;
            public string[] words;

            public Trie()
            {
                root = new Node('0');
            }

            public void Insert(string word, int index)
            {
                Node cur = root;
                foreach (char c in word)
                {
                    if (!cur.children.ContainsKey(c))
                    {
                        cur.children.Add(c, new Node(c));
                    }
                    cur = cur.children[c];
                }
                cur.end = index;
            }

            /// <summary>
            /// 直接用深度优先搜索算法求最长单词
            /// </summary>
            /// <returns></returns>
            public string Dfs()
            {
                string ans = "";
                Stack<Node> stack = new Stack<Node>();
                stack.Push(root);
                while (stack.Count != 0)
                {
                    Node node = stack.Pop();
                    if (node.end > 0 || node == root)
                    {
                        if (node != root)
                        {
                            string word = words[node.end - 1];
                            if (word.Length > ans.Length || (word.Length == ans.Length && word.CompareTo(ans) < 0))
                            {
                                ans = word;
                            }
                        }
                        foreach (Node n in node.children.Values)
                        {
                            stack.Push(n);
                        }
                    }
                }
                return ans;

            }

        }



    }
}