using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 28. 找出字符串中第一个匹配项的下标
    /// https://leetcode.cn/problems/find-the-index-of-the-first-occurrence-in-a-string/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>


    public class Solution_28
    {
        public void Run()
        {
            string haystack = "mississippi";
            string needle = "issip";
            int res = StrStr_2(haystack, needle);
            Console.WriteLine("res:{0}", res);




        }

        // 我的题解0，没有特别算法，按题意直写
        // 直接遍历两个字符串
        // 时间复杂度：O(n*m)，空间复杂度：O(1)
        public int StrStr_My_0(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
            {
                return -1;
            }
            for (int i = 0; i < haystack.Length; i++)
            {
                int j = i;
                for (int k = 0; k < needle.Length; k++)
                {
                    if (haystack[j] == needle[k])
                    {
                        if (k == needle.Length - 1)
                        {
                            // 完全匹配
                            return j - needle.Length + 1;
                        }
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (haystack.Length - i - 1 < needle.Length)
                {
                    // 如果剩下长度过小，直接不符
                    return -1;
                }
            }
            return -1;

        }


        // method 1-官方题解1
        // 暴力匹配
        // 和“我的题解0”是一样的思路，不过官方写的更好，比我简洁很多
        // 时间复杂度：O(n*m)，空间复杂度：O(1)
        public int StrStr_1(string haystack, string needle)
        {
            // 考虑haystack = needle情况，i + needle.Length <= haystack.Length 可以写等于号
            // 这个i + needle.Length的设计更方便计算如果haystack剩下长度过小的情况
            for (int i = 0; i + needle.Length <= haystack.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < needle.Length; j++)
                {
                    // 这个i+j的设计更方便计算索引
                    if (haystack[i + j] != needle[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;

        }

        // method 2-官方题解2
        // KMP算法
        // 官方解释没讲清楚，尤其是“真前后缀”的定义。
        // 我对KMP算法理解是：尽可能快进needle的匹配起点。
        // 理解“真前后缀”、“前缀函数”：对needle子串作轴对称，拿到轴对称最多的单词长度。下面是任意子串举例：
        // 比如："a"轴对称，无法轴对称，长度为0；
        // 比如："aa"轴对称，就是左边一个a右边一个a，长度为1；
        // 比如："aaa"轴对称，就是左边两个a右边两个a，长度为2；
        // 比如："aac"轴对称，无法轴对称，长度为0；
        // 比如："abcdab"轴对称，就是左边ab右边ab，长度为2；
        public int StrStr_2(string haystack, string needle)
        {
            // pi数组：查needle的前后缀
            int[] pi = new int[needle.Length];
            for (int i = 1, j = 0; i < needle.Length; i++)
            {
                while (j > 0 && needle[i] != needle[j])
                {
                    // j退回到上一个匹配索引，最多退回到起点
                    j = pi[j - 1];
                }

                if (needle[i] == needle[j])
                {
                    j++;
                }
                pi[i] = j;
            }

            for (int i = 0, j = 0; i < haystack.Length; i++)
            {
                while (j > 0 && haystack[i] != needle[j])
                {
                    // j退回到上一个匹配索引，最多退回到起点，想象一下这里在haystack可能已经有部分匹配了
                    // 相对于暴力匹配的needle匹配都从头开始，这里尝试快进needle匹配索引起点
                    j = pi[j - 1];
                }
                if (haystack[i] == needle[j])
                {
                    j++;
                }
                if (j == needle.Length)
                {
                    // needle已经走完，即已经完全匹配
                    return i - needle.Length + 1;
                }
            }
            return -1;

        }




    }

}