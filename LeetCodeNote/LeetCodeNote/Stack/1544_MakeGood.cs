using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 1544. 整理字符串
    /// https://leetcode-cn.com/problems/make-the-string-great/
    /// </summary>


    public class Solution_1544
    {
        // method 0
        public string MakeGood_0(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                string str = s[i].ToString(); 
                if (sb.Length > 0 && sb[sb.Length - 1].ToString().ToLower() == str.ToLower() && sb[sb.Length - 1].ToString() != str)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(str);
                }
            }
            return sb.ToString();

        }


    }

}