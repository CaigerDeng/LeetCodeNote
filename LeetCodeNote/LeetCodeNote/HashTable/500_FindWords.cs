using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace LeetCodeNote.HashTable
{

    /// <summary>
    /// 500. 键盘行
    /// https://leetcode-cn.com/problems/keyboard-row/
    /// </summary>
    public class Solution_500_FindWords
    {

        // method 0
        // 不用词典用正则
        public string[] FindWords_0(string[] words)
        {
            string[] res = (from word in words
                            where Regex.Match(word, string.Format("[qwertyuiop]{{{0}}}$|[asdfghjkl]{{{0}}}$|[zxcvbnm]{{{0}}}$", word.Length), RegexOptions.IgnoreCase).Success
                            select word).ToArray();
            return res;

        }


    }
}