using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1002. 查找常用字符
    /// https://leetcode-cn.com/problems/find-common-characters/
    /// </summary>

    public class Solution_1002
    {
        // mine
        // dic求每个词交集
        // method 0
        public IList<string> CommonChars_0(string[] A)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            Dictionary<char, int> intersectDic = new Dictionary<char, int>();
            for (int i = 0; i < A[0].Length; i++)
            {
                char k = A[0][i];
                if (!intersectDic.ContainsKey(k))
                {
                    intersectDic[k] = 1;
                }
                else
                {
                    intersectDic[k]++;
                }
            }
            for (int i = 1; i < A.Length; i++)
            {
                string content = A[i];
                dic.Clear();
                for (int j = 0; j < content.Length; j++)
                {
                    char k = content[j];
                    if (!dic.ContainsKey(k))
                    {
                        dic[k] = 1;
                    }
                    else
                    {
                        dic[k]++;
                    }
                }
                List<char> list = intersectDic.Keys.Intersect(dic.Keys).ToList();
                Dictionary<char, int> temp = new Dictionary<char, int>();
                for (int j = 0; j < list.Count; j++)
                {
                    char k = list[j];
                    int v = Math.Min(intersectDic[k], dic[k]);
                    temp[k] = v;
                }
                intersectDic = temp;
            }
            List<string> res = new List<string>();
            foreach (KeyValuePair<char, int> item in intersectDic)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    res.Add(item.Key.ToString());
                }
            }
            return res;

        }

        // method 1
        // 不用词典不用交集，直接看记录的最小值
        public IList<string> CommonChars_1(string[] A)
        {
            List<string> list = new List<string>();
            int[,] a = new int[100, 26];
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    // 记录每一个单词的每个字母出现次数
                    // a的ascii码为97
                    a[i, A[i][j] - 97] += 1;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                int min = 1000;
                for (int j = 0; j < A.Length; j++)
                {
                    if (min > a[j, i])
                    {
                        min = a[j, i];
                    }
                }
                // 直接看记录的最小值
                for (int j = 0; j < min; j++)
                {
                    char t = (char)(i + 97);
                    list.Add(t.ToString());
                }
            }
            return list;
        }



    }
}