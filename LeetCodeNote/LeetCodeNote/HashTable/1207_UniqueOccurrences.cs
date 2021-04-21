using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 1207. 独一无二的出现次数
    /// https://leetcode-cn.com/problems/unique-number-of-occurrences/
    /// </summary>


    public class Solution_1207_UniqueOccurrences
    {

        // method 0
        public bool UniqueOccurrences_0(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, 0);
                }
                dic[i]++;
            }
            HashSet<int> hs = new HashSet<int>();
            foreach (int value in dic.Values)
            {
                if (hs.Contains(value))
                {
                    return false;
                }
                hs.Add(value);
            }
            return true;

        }


    }


}