using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LeetCodeNote.Array
{
    /// <summary>
    /// 3. 无重复字符的最长子串
    /// https://leetcode.cn/problems/longest-substring-without-repeating-characters/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_3
    {

        public void Run()
        {
            //string s = "abcabcbb";
            //string s = "bbbbb";
            //string s = "pwwkew";
            string s = "ab";
            //string s = "aab";
            //string s = "dvdf";


            int res = LengthOfLongestSubstring_My_0(s);


            Console.WriteLine("res:{0}", res);

        }

        // (2025/2/8) method My 0-我的题解0
        // 用额外词典方便查找+双指针
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public int LengthOfLongestSubstring_My_0(string s)
        {
            // <值，索引>词典
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int left = 0;
            int right = 0;
            int lenMax = 0;
            while (right < s.Length)
            {
                char c = s[right];
                bool canAdd = dic.TryAdd(c, right);
                if (!canAdd)
                {
                    lenMax = Math.Max(lenMax, right - 1 - left + 1);
                    // 此时出现重复字母，重新开始数就需要end退到该字母第一次出现地方的下一位
                    left = dic[c] + 1;
                    right = left;
                    dic.Clear();
                }
                else
                {
                    right++;
                }
            }
            // 跳出while循环时，没有更新lenMax，这里再更新一遍
            lenMax = Math.Max(lenMax, right - 1 - left + 1);
            return lenMax;

        }

        // method 1-官方题解1
        // 滑动窗口，思路和“我的题解0”完全不一样，而且官方更快，因为我在重新数子串上浪费了时间
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public int LengthOfLongestSubstring_1(string s)
        {
            HashSet<char> hashSet = new HashSet<char>();
            // 因为有下面while循环代码内容，所以right初始值必须为-1
            int right = -1; 
            int lenMax = 0;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    // 左指针右移，下面右指针还会尝试移动
                    hashSet.Remove(s[i - 1]);
                }
                while (right + 1 < n && !hashSet.Contains(s[right + 1]))
                {
                    // 不断移动右指针
                    hashSet.Add(s[right + 1]);
                    right++;
                }
                lenMax = Math.Max(lenMax, right - i + 1);
            }
            return lenMax;

        }

    }

}
