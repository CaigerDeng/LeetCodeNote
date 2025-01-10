using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //string[] strs = { "a" };


            string res = LongestCommonPrefix_4(strs);
            Console.WriteLine("res:{0}", res);


        }

        // method 0 我的题解0
        // 按题意直写，横向扫描，一个单词比完再比下一个单词，没什么特别设计
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

        // method 1 官方题解1
        // 和“我的题解0”意思一样，只是写的不同。
        // 时间复杂度：O(m*n), 空间复杂度：O(1)
        public string LongestCommonPrefix_1(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            string prefix = strs[0];
            int count = strs.Length;
            for (int i = 1; i < count; i++)
            {
                prefix = LongestCommonPrefix_1_Detail(prefix, strs[i]);
                if (prefix.Length == 0)
                {
                    return "";
                }
            }
            return prefix;

        }

        public string LongestCommonPrefix_1_Detail(string str1, string str2)
        {
            int length = Math.Min(str1.Length, str2.Length);
            int index = 0;
            while (index < length && str1[index] == str2[index])
            {
                index++;
            }
            return str1.Substring(0, index);

        }

        // method 2 官方题解2
        // 纵向扫描，同时和每个单词的列比较。
        // 时间复杂度：O(m*n), 空间复杂度：O(1)
        public string LongestCommonPrefix_2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            // 用strs[0]来做纵向扫描，因为strs[0]会变，所以不用临时变量来存
            int length = strs[0].Length;
            int count = strs.Length;
            for (int i = 0; i < length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < count; j++)
                {
                    if (i == strs[j].Length || c != strs[j][i])
                    {
                        // 比较走到新单词的尽头，或者走不下去
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];

        }


        // method 3 官方题解3
        // 分治
        // deng：不复杂，感觉更像是为了分治而分治的解法
        // 时间复杂度：O(m*n), 空间复杂度：O(mlogn)（只是针对环境调用栈）
        public string LongestCommonPrefix_3(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            return LongestCommonPrefix_3_Detail(strs, 0, strs.Length - 1);

        }

        public string LongestCommonPrefix_3_Detail(string[] strs, int start, int end)
        {
            if (start == end)
            {
                return strs[start];
            }
            int mid = (end - start) / 2 + start;
            string lcpLeft = LongestCommonPrefix_3_Detail(strs, start, mid);
            string lcpRight = LongestCommonPrefix_3_Detail(strs, mid + 1, end);
            return CommonPrefix(lcpLeft, lcpRight);

        }

        public string CommonPrefix(string lcpLeft, string lcpRight)
        {
            int minLength = Math.Min(lcpLeft.Length, lcpRight.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (lcpLeft[i] != lcpRight[i])
                {
                    return lcpLeft.Substring(0, i);
                }
            }
            // 可能lcpRight长度比较小
            return lcpLeft.Substring(0, minLength);

        }

        // method 4 官方题解4
        // 二分查找
        // 时间复杂度：O(mnlogm), 空间复杂度：O(1)（只是针对环境调用栈）
        public string LongestCommonPrefix_4(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            int minLength = int.MaxValue;
            foreach (string str in strs)
            {
                // 虽说strs提供Min()的API，不过对于同样长度的单词它还有更细致的比较（比如“dog”和“car”），但用不上这种程度的比较，所以不用API
                minLength = Math.Min(minLength, str.Length);
            }
            int low = 0;
            int high = minLength;
            while (low < high)
            {
                int mid = (high - low + 1) / 2 + low;
                if (IsCommonPrefix(strs, mid))
                {
                    // 因为在最后返回strs[0].Substring(0, low)里low必须是正确的值，所以这里low可以走慢一点
                    // 同样，因为low被赋值为mid，为了防止死循环（比如：strs = { "a" }这种情况），算mid公式有要加1。
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return strs[0].Substring(0, low);

        }

        public bool IsCommonPrefix(string[] strs, int length)
        {
            string str0 = strs[0].Substring(0, length);
            int count = strs.Length;
            for (int i = 1; i < count; i++)
            {
                string str = strs[i];
                // 竖向列比较
                for (int j = 0; j < length; j++)
                {
                    if (str0[j] != str[j])
                    {
                        return false;
                    }
                }
            }
            return true;

        }



    }

}
