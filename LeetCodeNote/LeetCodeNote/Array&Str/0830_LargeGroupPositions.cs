using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 830. 较大分组的位置
    /// https://leetcode-cn.com/problems/positions-of-large-groups/
    /// </summary>
     
    public class Solution_830
    {
        // method 0
        public IList<IList<int>> LargeGroupPositions_0(string S)
        {
            List<IList<int>> res = new List<IList<int>>();
            int i = 0;
            int len = S.Length;
            for (int j = 0; j < len; j++)
            {
                if (j == len - 1 || S[j] != S[j + 1])
                {
                    if (j - i + 1 >= 3)
                    {
                        List<int> list = new List<int>();
                        list.Add(i);
                        list.Add(j);
                        res.Add(list);
                    }
                    i = j + 1;
                }
            }
            return res;
        }




    }
}