using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1122. 数组的相对排序
    /// https://leetcode-cn.com/problems/relative-sort-array/
    /// </summary>

    public class Solution_1122
    {

        // method 0
        public int[] RelativeSortArray_0(int[] arr1, int[] arr2)
        {
            List<int> list = arr2.ToList();
            arr1 = arr1.OrderBy(a => list.IndexOf(a)).OrderBy(a => list.IndexOf(a) == -1 ? a : 0).ToArray();
            return arr1;
        }



    }
}