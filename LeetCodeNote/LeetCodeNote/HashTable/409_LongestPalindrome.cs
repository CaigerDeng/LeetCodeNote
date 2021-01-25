using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 409. 最长回文串
    /// https://leetcode-cn.com/problems/longest-palindrome/
    /// </summary>


    public class Solution_409_LongestPalindrome
    {
        public int LongestPalindrome_0(string s)
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
            int res = 0;
            foreach (int v in dic.Values)
            {
                res += v / 2 * 2;
                if (v % 2 == 1 && res % 2 == 0)
                {
                    // res % 2 == 0保证以下只会执行一次
                    res++;
                }
            }
            return res;

        }



    }
}