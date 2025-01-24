using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1566. 重复至少 K 次且长度为 M 的模式
    /// https://leetcode-cn.com/problems/detect-pattern-of-length-m-repeated-k-or-more-times/
    /// </summary>


    public class Solution_1566
    {
        // method 0
        // 暴力
        public bool ContainsPattern_0(int[] arr, int m, int k)
        {
            int n = arr.Length;
            if (m * k > n)
            {
                // 由于pattern的长度为m，且需要重复k次，所以pattern起始位置应该在[0, n - m * k]之间。
                return false;
            }
            for (int i = 0; i <= n - m * k; i++)
            {
                int j = 0;
                for (j = i + m; j < i + m * k; j++)
                {
                    if (arr[j] != arr[j - m])
                    {
                        break;
                    }
                }
                if (j == i + m * k)
                {
                    // 就是上面的for循环正常走完
                    return true;
                }
            }
            return false;

        }

        // method 1
        // 正则
        // https://leetcode-cn.com/problems/detect-pattern-of-length-m-repeated-k-or-more-times/solution/zheng-ze-biao-da-shi-nb-by-hhgfy/
        public bool ContainsPattern_1(int[] arr, int m, int k)
        {
            string str = string.Join(",", arr) + ",";
            string pattern = string.Format(@"((\d+,){{{0}}})\1{{{1}}}", m, k - 1);
            return Regex.IsMatch(str, pattern);

        }


    }

}