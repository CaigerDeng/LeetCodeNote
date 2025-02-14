using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 383. 赎金信
    /// https://leetcode.cn/problems/ransom-note/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_383
    {

        public void Run()
        {

        }

        // (2025/2/14) method My 0-我的题解0
        // 按题意直写，用哈希表做判断
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool CanConstruct_My_0(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                dic.TryAdd(c, 0);
                dic[c]++;
            }
            foreach (char c in ransomNote)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]--;
                    if (dic[c] == 0)
                    {
                        dic.Remove(c);
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        // method 1-官方题解1
        // 和“我的题解0”思路一样，只是官方用的是数组
        // 时间复杂度：O(N)，空间复杂度：O(1)
        public bool CanConstruct_1(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }
            // 题意明确只有小写字母
            int[] arr = new int[26];
            foreach (char c in magazine)
            {
                arr[c - 'a']++;
            }
            foreach (char c in ransomNote)
            {
                arr[c - 'a']--;
                if (arr[c - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;

        }





    }


}
