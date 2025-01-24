using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1200. 最小绝对差
    /// https://leetcode-cn.com/problems/minimum-absolute-difference/
    /// </summary>

    public class Solution_1200
    {
        // method 0
        public IList<IList<int>> MinimumAbsDifference_0(int[] arr)
        {
            System.Array.Sort(arr);
            int min = int.MaxValue;
            List<IList<int>> res = new List<IList<int>>();
            for (int i = 1; i < arr.Length; i++)
            {
                int val = arr[i] - arr[i - 1];
                if (val < min)
                {
                    min = val;
                    res.Clear();
                }
                if (val == min)
                {
                    List<int> list = new List<int>();
                    list.Add(arr[i - 1]);
                    list.Add(arr[i]);
                    res.Add(list);
                }
            }
            return res;
        }



    }
}