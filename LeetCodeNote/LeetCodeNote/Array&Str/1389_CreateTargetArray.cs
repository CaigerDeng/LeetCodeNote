using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1389. 按既定顺序创建目标数组
    /// https://leetcode-cn.com/problems/create-target-array-in-the-given-order/
    /// </summary>

    public class Solution_1389
    {
        // method 1
        public int[] CreateTargetArray_0(int[] nums, int[] index)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                list.Insert(index[i], nums[i]);
            }
            return list.ToArray();

        }





    }


}