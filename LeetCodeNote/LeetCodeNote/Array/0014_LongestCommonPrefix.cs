using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 14. 最长公共前缀
    /// https://leetcode.cn/problems/longest-common-prefix/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_14
    {

        public void Run()
        {
            string[] strs = { "flower", "flow", "flight" };

            //string[] strs = { "dog", "racecar", "car" };

            //string[] strs = { "ab", "a" };


            string res = LongestCommonPrefix_My_0(strs);
            Console.WriteLine("res:{0}", res);


        }

        // method 0 我的题解0
        // 按题意直写，没什么特别设计
        public string LongestCommonPrefix_My_0(string[] strs)
        {
            int n = strs.Length;
            string firstStr = strs[0];
            if (n == 1)
            {
                return firstStr;
            }
            StringBuilder sb = new StringBuilder(firstStr);
            for (int i = 1; i < n; i++)
            {
                string str = strs[i];
                string tempSb = sb.ToString();
                int checkLen = tempSb.Length;
                if (str.Length < tempSb.Length)
                {
                    checkLen = str.Length;
                    // sb.Remove(a, b)：从a索引开始删，删b个数
                    sb.Remove(str.Length, tempSb.Length - str.Length); 
                }
                tempSb = sb.ToString();
                for (int j = 0; j < checkLen; j++)
                {
                    if (tempSb[j] != str[j])
                    {
                        if (j == 0)
                        {
                            return "";
                        }
                        sb.Remove(j, sb.ToString().Length - j);
                        break;
                    }
                }
            }
            return sb.ToString();


        }

    }

}
