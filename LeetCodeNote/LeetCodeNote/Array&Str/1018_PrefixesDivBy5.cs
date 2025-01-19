using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1018. 可被 5 整除的二进制前缀
    /// https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/
    /// </summary>

    public class Solution_1018
    {
        // method 0
        public IList<bool> PrefixesDivBy5_0(int[] A)
        {
            List<bool> res = new List<bool>();
            int num = 0;
            for (int i = 0; i < A.Length; i++)
            {
                // 下一个二进制前缀对应的十进制整数 = 上一次的结果左移一位（乘以2）的结果 + 这次的A[i]（0或者1）
                num = num * 2 + A[i];
                // 可被5整除的数字只跟该数字的最后一位数字（为0或5）有关系，于是不需要具体的算出二进制前缀对应的十进制整数是多少，只需每次保留最后一位数字（保留用该数字对10取余的十进制整数的结果）就好
                num %= 10;
                res.Add(num % 5 == 0);
            }
            return res;
        }

    }
}