using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 392. 判断子序列
    /// https://leetcode.cn/problems/is-subsequence/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_392
    {
        public void Run()
        {

            string s = "abc";
            string t = "ahbgdc";


            bool res = IsSubsequence_My_0(s, t);


            Console.WriteLine("res:{0}", res);

        }

        // 我的题解0，没有特别算法，按题意直写
        // 双指针
        // 时间复杂度：O(n)，空间复杂度：O(1)
        public bool IsSubsequence_My_0(string s, string t)
        {
            if (s.Length == 0)
            {
                return true;
            }
            if (s.Length > t.Length)
            {
                return false;
            }
            int j = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == s[j])
                {
                    j++;
                }
                if (j == s.Length)
                {
                    return true;
                }
            }
            return false;

        }

        // method 1-官方题解1
        // 和“我的题解0”思路一样，只是写法不同
        // 时间复杂度：O(n或m)（我觉得官方这里的时间复杂度写错了），空间复杂度：O(1)
        public bool IsSubsequence_1(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int i = 0;
            int j = 0;
            while (i < n && j < m)
            {
                if (s[i] == t[j])
                {
                    i++;
                }
                j++;
            }
            return i == n;

        }

        // method 2-官方题解2
        // 动态规划，针对s的量超多（多过10亿）的进阶情况，这里就需要对t进行预处理，为了尽可能快进t的匹配起点
        // 时间复杂度：O(26*m+n)，空间复杂度：O(26*m)
        public bool IsSubsequence_2(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            // 26代表26个字母
            int[,] f = new int[m + 1, 26];
            for (int i = 0; i < 26; i++)
            {
                // 最后一行所有列（即26个字母列）都填上m，代表结束
                f[m, i] = m;
            }
            // 倒序原因：使f[i, j] = f[i + 1, j];合理，不然正序根本得不到f[i + 1, j]值
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (t[i] == j + 'a')
                    {
                        // 在i索引有字母x
                        f[i, j] = i;
                    }
                    else
                    {
                        // 最外层for倒序的原因
                        // 从最后一行开始，从左到右依次填充数据，数据是会传递上去的。
                        // 比如：字母a只出现在索引0、5、10，那在第m行到第11行数据都是m，第10行到第4行的数据都会是10，第5行到第1行数据都会是5，第0行数据是0。
                        // 比如：t中没有字母b，那这一列所有行都会是结束标记m。
                        f[i, j] = f[i + 1, j];
                    }
                }
            }
            int add = 0;
            for (int i = 0; i < n; i++)
            {
                int j = s[i] - 'a';
                if (f[add, j] == m)
                {
                    // 找到结束标志，肯定不匹配
                    return false;
                }
                // 跳到待检测新一行，比如：字母a只出现在索引5，那待检测新一行就是6，下一个字母只能出现在索引6及之后。其实就是遍历t。
                add = f[add, j] + 1;
            }
            return true;

        }



    }



}
