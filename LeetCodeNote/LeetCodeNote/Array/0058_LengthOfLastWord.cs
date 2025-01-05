using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 58. 最后一个单词的长度
    /// https://leetcode.cn/problems/length-of-last-word/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_58
    {

        public void Run()
        {
            //string str = "Hello World";
            //string str = "   fly me   to   the moon  ";
            string str = "ab";

            int res = LengthOfLastWord_My_0(str);
            Console.WriteLine("res:{0}", res);


        }

        // method 0 我的题解0
        // 按题意直写，没什么特别设计
        public int LengthOfLastWord_My_0(string s)
        {
            int n = s.Length;
            int a = -1;
            int b = -1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (b == -1 && s[i] != ' ')
                {
                    b = i;
                    continue;
                }
                if (b != -1 && s[i] == ' ')
                {
                    a = i + 1;
                    break;
                }
            }

            // 调试用
            //StringBuilder sb = new StringBuilder();
            //if (a >= 0)
            //{
            //    for (int i = a; i <= b; i++)
            //    {
            //        sb.Append(s[i]);
            //    }
            //    Console.WriteLine("cut str:{0}", sb.ToString());

            //}

            return a == -1 ? b + 1 : b - a + 1;

        }

        // method 1 官方题解1
        // 和“我的题解0”意思一样，只是写法不同
        public int LengthOfLastWord_1(string s)
        {
            int index = s.Length - 1;
            while (s[index] == ' ')
            {
                index--;
            }
            int wordLength = 0;
            while (index >= 0 && s[index] != ' ')
            {
                wordLength++;
                index--;
            }
            return wordLength;

        }



    }
}
