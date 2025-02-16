using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 49. 字母异位词分组
    /// https://leetcode.cn/problems/group-anagrams/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_49
    {

        public void Run()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            //string[] strs = new string[] { "", "b" };


            IList<IList<string>> resList = GroupAnagrams_1(strs);
            Console.WriteLine("end.");



        }

        // (2025/2/15) method My 0-我的题解0
        // 按题意直写，对每一个单词都构造一个词典A，为了后面方便查找历史，把词典A变成一个字符串（有格式）。耗时63ms。
        // 词典A如果不变成字符串，而是词典和词典的比较，耗时会翻10倍，变成691ms！
        // 时间复杂度：O(nklogk)，空间复杂度：O(nk)
        public IList<IList<string>> GroupAnagrams_My_0(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            Dictionary<char, int> tempDic = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            foreach (string word in strs)
            {
                tempDic.Clear();
                sb.Clear();
                foreach (char c in word)
                {
                    tempDic.TryAdd(c, 0);
                    tempDic[c]++;
                }
                foreach (KeyValuePair<char, int> kv in tempDic.OrderBy(kv => kv.Key))
                {
                    sb.Append(kv.Key);
                    sb.Append("_");
                    sb.Append(kv.Value);
                    sb.Append(",");
                }
                string key = sb.ToString();
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(word);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(word);
                    dic.Add(key, list);
                }
            }

            IList<IList<string>> resList = new List<IList<string>>();
            foreach (List<string> val in dic.Values)
            {
                resList.Add(val);
            }
            return resList;

        }


        // method 1-官方题解1
        // 和“我的题解0”思路几乎一样，只是在构造字符串时官方写的更好更简洁（完全不用考虑格式，我还写了格式）
        // 耗时19ms。
        // 时间复杂度：O(nklogk)，空间复杂度：O(nk)
        public IList<IList<string>> GroupAnagrams_1(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach (string word in strs)
            {
                char[] arr = word.ToCharArray();
                System.Array.Sort(arr);
                string key = new string(arr);
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(word);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(word);
                    dic.Add(key, list);
                }
            }
            IList<IList<string>> resList = new List<IList<string>>();
            foreach (List<string> val in dic.Values)
            {
                resList.Add(val);
            }
            return resList;

        }

        // method 2-官方题解2
        // 和“官方题解1”思路一样，只是不用哈希表而是用数组
        // 耗时26ms。
        // 时间复杂度：O(n(k+∣Σ∣))，空间复杂度：O(n(k+∣Σ∣))
        public IList<IList<string>> GroupAnagrams_2(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach (string word in strs)
            {
                // 26个字母
                int[] arr = new int[26];
                foreach (char c in word)
                {
                    arr[c - 'a']++;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    if (arr[i] > 0)
                    {
                        sb.Append('a' + i);
                        sb.Append(arr[i]);
                    }
                }
                string key = sb.ToString();
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(word);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(word);
                    dic.Add(key, list);
                }
            }
            IList<IList<string>> resList = new List<IList<string>>();
            foreach (List<string> val in dic.Values)
            {
                resList.Add(val);
            }
            return resList;

        }





    }


}
