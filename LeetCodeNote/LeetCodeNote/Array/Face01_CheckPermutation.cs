using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 01.02. 判定是否互为字符重排
    /// https://leetcode-cn.com/problems/check-permutation-lcci/
    /// </summary>

    public class Solution_Face01_02
    {

        // method 0
        public bool CheckPermutation_0(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            List<char> list1 = s1.ToList();
            list1.Sort();
            List<char> list2 = s2.ToList();
            list2.Sort();
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }
            return true;

        }

        // method 1
        public bool CheckPermutation_1(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                if (!dic.ContainsKey(c))
                {
                    dic[c] = 0;
                }
                dic[c]++;
            }
            foreach (var c in s2)
            {
                if (!dic.ContainsKey(c))
                {
                    return false;
                }
                dic[c]--;
                if (dic[c] < 0)
                {
                    return false;
                }
            }
            return true;

        }



    }


}