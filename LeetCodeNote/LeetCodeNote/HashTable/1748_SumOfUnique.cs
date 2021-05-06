using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.HashTable
{

    /// <summary>
    /// 1748. 唯一元素的和
    /// https://leetcode-cn.com/problems/sum-of-unique-elements/
    /// </summary>

    public class Solution_1748_SumOfUnique
    {
        // method 0
        public int SumOfUnique_0(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
            }
            int sum = 0;
            foreach (KeyValuePair<int, int> pair in dic)
            {
                if (pair.Value == 1)
                {
                    sum += pair.Key;
                }
            }
            return sum;

        }

    }
}