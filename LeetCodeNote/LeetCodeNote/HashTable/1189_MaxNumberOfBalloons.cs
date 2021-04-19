using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 1189. “气球” 的最大数量
    /// https://leetcode-cn.com/problems/maximum-number-of-balloons/
    /// </summary>


    public class Solution_1189_MaxNumberOfBalloons
    {
        // method 0
        public int MaxNumberOfBalloons_0(string text)
        {
            List<char> keyList = new List<char>();
            keyList.Add('b');
            keyList.Add('a');
            keyList.Add('l');
            keyList.Add('o');
            keyList.Add('n');
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in keyList)
            {
                dic.Add(c, 0);
            }
            foreach (char c in text)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
            }
            int res = 0;
            while (dic['b'] > 0)
            {
                foreach (char c in keyList)
                {
                    dic[c]--;
                    if (c == 'o' || c == 'l')
                    {
                        dic[c]--;
                    }
                    if (dic[c] < 0)
                    {
                        return res;
                    }
                }
                res++;
            }
            return res;

        }


        // method 1
        public int MaxNumberOfBalloons_1(string text)
        {
            int[] arr = new int[5];
            foreach (char c in text)
            {
                if (c == 'b')
                {
                    arr[0]++;
                }
                else if (c == 'a')
                {
                    arr[1]++;
                }
                else if (c == 'l')
                {
                    arr[2]++;
                }
                else if (c == 'o')
                {
                    arr[3]++;
                }
                else if (c == 'n')
                {
                    arr[4]++;
                }
            }
            arr[2] /= 2;
            arr[3] /= 2;
            int res = int.MaxValue;
            foreach (int i in arr)
            {
                res = Math.Min(res, i);
            }
            return res;

        }



    }

}