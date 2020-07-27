using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1313. 解压缩编码列表
    /// https://leetcode-cn.com/problems/decompress-run-length-encoded-list/
    /// </summary>


    public class Solution_1313
    {
        // method 0     
        public int[] DecompressRLElist_0(int[] nums)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                int freq = nums[i];
                int val = nums[i + 1];
                for (int j = 0; j < freq; j++)
                {
                    list.Add(val);
                }
            }
            int[] res = list.ToArray();
            return res;

        }

    }
}