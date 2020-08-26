using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1512. 好数对的数目
    /// https://leetcode-cn.com/problems/number-of-good-pairs/
    /// </summary>


    public class Solution_1512
    {
        // method 0
        // 暴力
        public int NumIdenticalPairs_0(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        res++;
                    }
                }
            }
            return res;

        }

        // method 1
        // 组合公式 C（上标为n，下标为2），即 n * (n - 1) / 2
        public int NumIdenticalPairs_1(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int k = nums[i];
                if (!dic.ContainsKey(k))
                {
                    dic[k] = 0;
                }
                dic[k]++;
            }
            int res = 0;
            foreach (int val in dic.Values)
            {
                res += val * (val - 1) / 2;
            }
            return res;

        }




    }


}