using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 811. 子域名访问计数
    /// https://leetcode-cn.com/problems/subdomain-visit-count/
    /// </summary>


    public class Solution_811_SubdomainVisits
    {
        // method 0
        public IList<string> SubdomainVisits_0(string[] cpdomains)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string domain in cpdomains)
            {
                string[] pair = domain.Split(' ');
                string[] frags = pair[1].Split('.');
                int count = int.Parse(pair[0]);
                string cur = "";
                for (int i = frags.Length - 1; i >= 0; i--)
                {
                    if (i == frags.Length -1)
                    {
                        cur = frags[i];
                    }
                    else
                    {
                        cur = frags[i] + "." + cur;
                    }
                    if (!dic.ContainsKey(cur))
                    {
                        dic.Add(cur, 0);
                    }
                    dic[cur] += count;
                }
            }
            List<string> ans = new List<string>();
            foreach (KeyValuePair<string, int> pair in dic)
            {
                ans.Add(string.Format("{0} {1}", pair.Value, pair.Key));
            }
            return ans;

        }

    }


}