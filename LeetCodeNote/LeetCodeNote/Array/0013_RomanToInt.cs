using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 13. 罗马数字转整数
    /// https://leetcode.cn/problems/roman-to-integer/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_13
    {

        public void Run()
        {
            string s = "MCMXCIV";
            //string s = "IV";
            int res = RomanToInt_My_0(s);
            Console.WriteLine(res);


        }

        // method 0 我的题解0
        // 按题意直写，没什么特别设计
        public int RomanToInt_My_0(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic['I'] = 1;
            dic['V'] = 5;
            dic['X'] = 10;
            dic['L'] = 50;
            dic['C'] = 100;
            dic['D'] = 500;
            dic['M'] = 1000;
            dic['_'] = 0; // 哨兵

            int res = 0;
            int n = s.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                char currChar = s[i];
                char behindChar = i + 1 < n ? s[i + 1] : '_';
                if (dic[currChar] < dic[behindChar])
                {
                    res -= dic[currChar];
                }
                else
                {
                    res += dic[currChar];
                }
            }
            return res;

        }


        // 因为“官方题解1️”和“我的题解0”一样，所以在此略过


    }
}
