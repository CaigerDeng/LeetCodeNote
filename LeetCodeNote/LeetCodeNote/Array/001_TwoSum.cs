using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 1. 两数之和
/// https://leetcode-cn.com/problems/two-sum/
/// </summary>

namespace LeetCodeNote.Array
{
    public class Solution_1
    {

        //method 0
        public int[] TwoSum_0(int[] nums, int target)
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

        //method 1 
        public int[] TwoSum_1(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, i);
                }
                dic[key] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int left = target - nums[i];
                if (dic.ContainsKey(left) && dic[left] != i)
                {
                    return new[] { i, dic[left] };
                }
            }
            return null;
        }

        //method 2 
        public int[] TwoSum_2(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                int left = target - key;
                // can remove '&& dic[left] != i'
                if (dic.ContainsKey(left))
                {
                    return new[] { i, dic[left] };
                }
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, i);
                }
                dic[key] = i;
            }           
            return null;
        }

    }

}
