using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 76. 最小覆盖子串
    /// https://leetcode.cn/problems/minimum-window-substring/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_76
    {
        public void Run()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC"; // res: "BANC"

            //string s = "a";
            //string t = "a"; // res: "aa"

            //string s = "a";
            //string t = "aa"; // res:""

            //string s = "aaflslflsldkalskaaa";
            //string t = "aaa"; // res:"aaa"

            //string s = "acbba";
            //string t = "aab"; // res:"acbba"




            string res = MinWindow_My_0(s, t);
            Console.WriteLine(res);

        }

        // (2025/2/9) method My 0-我的题解0
        // 在s上一个一个字母移动，来遍历t找对应覆盖子串
        // 失败！超出时限！最后测试用例的s长到放vs都卡，更别说执行我这算法了。
        // 时间复杂度:O(N*N)，空间复杂度：O(N)
        public string MinWindow_My_0(string s, string t)
        {
            string res = string.Empty;
            int minLen = int.MaxValue;
            if (s.Length < t.Length)
            {
                return res;
            }
            Dictionary<char, int> oriDic = new Dictionary<char, int>();
            foreach (char c in t)
            {
                oriDic.TryAdd(c, 0);
                oriDic[c]++;
            }
            Dictionary<char, int> dic;
            for (int i = 0; i < s.Length; i++)
            {
                dic = new Dictionary<char, int>(oriDic);
                for (int j = i; j < s.Length; j++)
                {
                    char c = s[j];
                    if (dic.ContainsKey(c))
                    {
                        dic[c]--;
                        if (dic[c] == 0)
                        {
                            dic.Remove(c);
                        }
                    }
                    if (dic.Count == 0)
                    {
                        int len = j - i + 1;
                        string word = s.Substring(i, len);
                        // len必须至少有t.Length这么长
                        if (len >= t.Length && len < minLen)
                        {
                            minLen = len;
                            res = word;
                        }
                        break;
                    }
                }
            }
            return res;

        }

        // method 1_0-官方题解1
        // 滑动窗口
        // 时间复杂度:O(N)，空间复杂度：O(N)
        public string MinWindow_1_0(string s, string t)
        {
            int sLen = s.Length;
            int tLen = t.Length;

            int left = 0;
            int right = 0;

            int minLen = int.MaxValue;
            int resLeft = 0;
            int resRight = 0;

            string res = string.Empty;
            Dictionary<char, int> oriDic = new Dictionary<char, int>();
            Dictionary<char, int> currDic = new Dictionary<char, int>();
            foreach (char c in t)
            {
                oriDic[c] = oriDic.GetValueOrDefault(c, 0) + 1;
            }
            while (right < sLen)
            {
                if (right < sLen && oriDic.ContainsKey(s[right]))
                {
                    char c = s[right];
                    currDic[c] = currDic.GetValueOrDefault(c, 0) + 1;
                }
                // 在有效窗口内（检测currDic是否每个值不低于oriDic对应值，如果为true，说明是有效窗口），尝试缩减左边界
                while (Check(oriDic, currDic) && left <= right)
                {
                    if (right - left + 1 < minLen)
                    {
                        minLen = right - left + 1;
                        resLeft = left;
                        resRight = right;
                        res = s.Substring(resLeft, resRight - resLeft + 1);
                    }
                    // 尝试缩减左边界，缩小窗口
                    if (oriDic.ContainsKey(s[left]))
                    {
                        char c = s[left];
                        currDic[c] = currDic.GetValueOrDefault(c, 0) - 1;
                    }
                    left++;
                }
                // 右边界正常右移，扩大窗口
                right++;
            }
            return res;

        }

        // 检测currDic是否每个值不低于oriDic对应值
        private bool Check(Dictionary<char, int> oriDic, Dictionary<char, int> currDic)
        {
            foreach (KeyValuePair<char, int> pair in oriDic)
            {
                if (currDic.GetValueOrDefault(pair.Key, 0) < pair.Value)
                {
                    return false;
                }
            }
            return true;

        }

        // method 1_1-针对官方题解1的进一步优化
        // 优化点：预处理s，只关心有用的字符
        // 时间复杂度:O(N)，空间复杂度：O(N)
        public string MinWindow_1_1(string s, string t)
        {
            int sLen = s.Length;
            int tLen = t.Length;

            int left = 0;
            int right = 0;

            int minLen = int.MaxValue;
            string res = string.Empty;
            if (sLen < tLen)
            {
                return res;
            }

            Dictionary<char, int> oriDic = new Dictionary<char, int>();
            Dictionary<char, int> currDic = new Dictionary<char, int>();
            foreach (char c in t)
            {
                oriDic[c] = oriDic.GetValueOrDefault(c, 0) + 1;
            }
            // 预处理s，只保留 t 中出现的字符
            List<(int index, char c)> filteredS = new List<(int index, char c)>();
            for (int i = 0; i < sLen; i++)
            {
                char c = s[i];
                if (oriDic.ContainsKey(c))
                {
                    filteredS.Add((i, c));
                }
            }
            // 一共需要几种字母
            int required = oriDic.Count; 
            int matched = 0;
            int start = 0; 
            while (right < filteredS.Count)
            {
                char c = filteredS[right].c;
                currDic[c] = currDic.GetValueOrDefault(c, 0) + 1;
                if (currDic[c] == oriDic[c])
                {
                    matched++;
                }
                // 当t的所有字母都匹配上时，即覆盖子串出现
                while (matched == required)
                {
                    int startIndex = filteredS[left].index;
                    int endIndex = filteredS[right].index;
                    int windowLen = endIndex - startIndex + 1;
                    if (windowLen < minLen)
                    {
                        minLen = windowLen;
                        start = startIndex;
                        res = s.Substring(start, minLen);
                    }
                    // 左边界尝试缩减
                    char leftC = filteredS[left].c;
                    currDic[leftC]--;
                    if (currDic[leftC] < oriDic[leftC])
                    {
                        // 跳出while循环
                        matched--;
                    }
                    left++;
                }
                // 右边界正常右移，扩大窗口
                right++;
            }
            return res;

        }



    }

}
