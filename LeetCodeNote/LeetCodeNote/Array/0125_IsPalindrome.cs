using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 125. 验证回文串
    /// https://leetcode.cn/problems/valid-palindrome/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_125
    {
        public void Run()
        {

            string s = "A man, a plan, a canal: Panama";

            //string s = " ";

            //string s = "race a car";

            bool res = IsPalindrome_1_0(s);


            Console.WriteLine("res:{0}", res);

        }

        // 我的题解0，没有特别算法，按题意直写
        // 双指针，但尽可能少预处理（因为我觉得没必要）
        // 时间复杂度：O(n)，空间复杂度：O(1)
        public bool IsPalindrome_My_0(string s)
        {
            int i = 0;
            s = s.ToLower();
            int j = s.Length - 1;
            while (true)
            {
                while (char.IsLetterOrDigit(s[i]) == false)
                {
                    i++;
                    if (i == s.Length)
                    {
                        return true;
                    }
                }
                while (char.IsLetterOrDigit(s[j]) == false)
                {
                    j--;
                    if (j < 0)
                    {
                        return true;
                    }
                }
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
                if (i == j)
                {
                    break;
                }
                if (i == s.Length || j < 0)
                {
                    return true;
                }
            }
            return true;

        }

        // method 1_0-官方题解1
        // 使用Reverse接口
        // 时间复杂度：O(n)，空间复杂度：O(n)
        public bool IsPalindrome_1_0(string s)
        {
            StringBuilder sgood = new StringBuilder();
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char ch = s[i];
                if (char.IsLetterOrDigit(ch))
                {
                    // 必须先保证是字母或数字，才能进行后面的Reverse
                    sgood.Append(char.ToLower(ch));
                }
            }
            string s0 = sgood.ToString();
            string s1 = new string(s0.Reverse().ToArray());
            return s0 == s1;

        }

        // method 1_1-官方题解1_1
        // 思路和“我的题解0”一样，官方有完整预处理
        // 时间复杂度：O(n)，空间复杂度：O(n)
        public bool IsPalindrome_1_1(string s)
        {
            StringBuilder sgood = new StringBuilder();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char ch = s[i];
                if (char.IsLetterOrDigit(ch))
                {
                    // 必须先保证是字母或数字，才能进行后面的Reverse
                    sgood.Append(char.ToLower(ch));
                }
            }
            int n = sgood.Length;
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                if (char.ToLower(sgood[left]) != char.ToLower(sgood[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;

        }

        // method 2-官方题解2
        // 思路和“我的题解0”完全一样，但官方写得更好更简洁
        // 时间复杂度：O(n)，空间复杂度：O(1)
        public bool IsPalindrome_2(string s)
        {
            int n = s.Length;
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                }
                left++;
                right--;
            }
            return true;

        }



    }













}
