using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1431. 拥有最多糖果的孩子
    /// https://leetcode-cn.com/problems/kids-with-the-greatest-number-of-candies/
    /// </summary>


    public class Solution_1431
    {
        // method 0
        public IList<bool> KidsWithCandies_0(int[] candies, int extraCandies)
        {
            List<bool> list = new List<bool>();
            int max = candies.Max();
            for (int i = 0; i < candies.Length; i++)
            {
                bool res = candies[i] + extraCandies >= max ;
                list.Add(res);
            }
            return list;

        }





    }
}