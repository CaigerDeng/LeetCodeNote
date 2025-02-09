using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1. 两数之和
    /// https://leetcode-cn.com/problems/two-sum/
    /// </summary>
    public class Solution_1
    {

        public void Run()
        {

        }

        // (2025/2/8) method My 0-我的题解0
        // 打头双指针的暴力查找
        // 时间复杂度：O(N*N)，空间复杂度：O(1)
        public int[] TwoSum_My_0(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new[] { i, j };
                    }
                }
            }
            return null;

        }

        // method 1-官方题解1
        // 和“我的题解0”一模一样，此处略过
        // //////////////////////////////////////////

        // method 2-官方题解2
        // 哈希表来优化查找
        // 时间复杂度：O(N)，空间复杂度：O(N)（指哈希表开销）
        public int[] TwoSum_2(int[] nums, int target)
        {
            // <值，索引>词典
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                int b = target - a;
                // 必须先写这个判断，因为重复元素不符题意，
                // 比如：nums为[3,2,4]，如果把这个判断滞后，那拿到的结果就会是[0,0]
                if (dic.ContainsKey(b))
                {
                    return new[] { i, dic[b] };
                }
                dic.TryAdd(a, i);
                dic[a] = i;
            }
            return null;

        }

    }

}
