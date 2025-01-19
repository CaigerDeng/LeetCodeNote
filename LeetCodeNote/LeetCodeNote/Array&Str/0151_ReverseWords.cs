using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 151. 反转字符串中的单词
    /// https://leetcode.cn/problems/reverse-words-in-a-string/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_151
    {

        public void Run()
        {
            string s = "the sky is blue";

            //string s = "a good   example";

            //string s = "  hello world  ";

            string res = ReverseWords_3(s);
            Console.WriteLine("res:{0}", res);


        }

        // method 0 我的题解0
        // 按题意直写，用开关来解决遇到空格的问题
        // 时间复杂度O(n)，空间复杂度O(n)
        public string ReverseWords_My_0(string s)
        {
            int n = s.Length;
            bool isSpace = false;
            StringBuilder sb = new StringBuilder();
            // 正序遍历处理多余空格
            for (int i = 0; i < n; i++)
            {
                if (s[i] == ' ' && isSpace)
                {
                    continue;
                }
                if (s[i] != ' ')
                {
                    sb.Append(s[i]);
                    isSpace = false;
                }
                else
                {
                    if (isSpace == false && sb.Length > 0)
                    {
                        sb.Append(s[i]); // 保证第一个加进去的肯定是字母
                        isSpace = true;
                    }
                }
            }
            // 可能末尾还会多一个空格
            if (sb.ToString()[^1] == ' ')
            {
                sb.Remove(sb.Length - 1, 1);
            }
            s = sb.ToString();
            sb.Clear();

            n = s.Length;
            int a = n - 1;
            int b = n - 1;
            bool canAdd = false;
            isSpace = false;
            // 倒序遍历处理反转
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    canAdd = true;
                    a = i + 1;
                    isSpace = true;
                }
                if (i == 0)
                {
                    canAdd = true;
                }
                if (canAdd)
                {
                    if (i == 0)
                    {
                        a = 0;
                    }
                    for (int j = a; j <= b; j++)
                    {
                        sb.Append(s[j]);
                    }
                    if (isSpace)
                    {
                        sb.Append(s[i]);
                        isSpace = false;
                        b = i - 1;
                    }
                    canAdd = false;
                }
            }
            return sb.ToString();


        }

        // method 1 官方题解1
        // 直接调用API
        // 时间复杂度O(n)，空间复杂度O(n)
        public string ReverseWords_1(string s)
        {
            // StringSplitOptions.RemoveEmptyEntries对头尾有多余空格的情况同样有效
            List<string> list = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            list.Reverse();
            string res = string.Join(" ", list);
            return res;

        }

        // method 2 官方题解2
        // 字符串整体翻转，再去多余空格，再单词反转。但自己实现API！想理解API实现细节可以一看。
        // 时间复杂度O(n)，空间复杂度O(n)
        public string ReverseWords_2(string s)
        {
            StringBuilder sb = TrimSpaces(s);
            Reverse(sb, 0, sb.Length - 1);
            ReverseEachWord(sb);
            return sb.ToString();

        }

        public StringBuilder TrimSpaces(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            // 去掉字符串开头的空白字符
            while (left <= right && s[left] == ' ')
            {
                left++;
            }
            // 去掉字符串末尾的空白字符
            while (left <= right && s[right] == ' ')
            {
                right--;
            }
            // 将字符串间多余的空白字符去除
            StringBuilder sb = new StringBuilder();
            while (left <= right)
            {
                char c = s[left];
                if (c != ' ')
                {
                    sb.Append(c);
                }
                else if (sb[sb.Length - 1] != ' ')
                {
                    sb.Append(c);
                }
                left++;
            }
            return sb;

        }

        public void Reverse(StringBuilder sb, int left, int right)
        {
            while (left < right) // 当left==right时，反转无意义，所以可以不写等于
            {
                (sb[left], sb[right]) = (sb[right], sb[left]);
                left++;
                right--;
            }

        }

        public void ReverseEachWord(StringBuilder sb)
        {
            int n = sb.Length;
            int start = 0;
            int end = 0;
            while (start < n)
            {
                // 走到该单词的末尾
                while (end < n && sb[end] != ' ')
                {
                    end++;
                }
                Reverse(sb, start, end - 1);
                // 更新start，去找下一个单词
                start = end + 1;
                end++;
            }


        }

        // method 3 官方题解3
        // 使用栈来存单词，在出栈的时候就能得到反着的效果
        // 时间复杂度O(n)，空间复杂度O(n)
        public string ReverseWords_3(string s)
        {
            int left = 0, right = s.Length - 1;
            // 去掉字符串开头的空白字符
            while (left <= right && s[left] == ' ')
            {
                ++left;
            }
            // 去掉字符串末尾的空白字符
            while (left <= right && s[right] == ' ')
            {
                --right;
            }
            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            while (left <= right)
            {
                char c = s[left];
                if (c == ' ' && sb.Length > 0)
                {
                    // 保存单词到队列，注意这里都不会保存空格
                    stack.Push(sb.ToString());
                    sb.Clear();
                }
                else if (c != ' ')
                {
                    sb.Append(c);
                }
                left++;
            }
            // 不要忘记加上最后一个单词
            stack.Push(sb.ToString());
            string res = string.Join(" ", stack);
            return res;

        }



    }

}
