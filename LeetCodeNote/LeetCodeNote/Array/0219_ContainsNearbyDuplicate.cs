using System;
using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 219. 存在重复元素 II
    /// https://leetcode.cn/problems/contains-duplicate-ii/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_219
    {

        public void Run()
        {
            //int[] nums = new[] { 1, 2, 3, 1 };
            //int k = 3;// res:true

            //int[] nums = new[] { 1, 0, 1, 1 };
            //int k = 1; // res:true

            int[] nums = new[] { 1, 2, 3, 1, 2, 3 };
            int k = 2; // res:false

            bool res = ContainsNearbyDuplicate_My_0(nums, k);
            Console.WriteLine("res:{0}", res);

        }


        // (2025/2/17) method My 0-我的题解0
        // 在遍历数组时，利用哈希表判断重复
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool ContainsNearbyDuplicate_My_0(int[] nums, int k)
        {
            // <数组元素, 对应索引列表> 可能会有重复元素，所以要用列表
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    List<int> list = dic[nums[i]];
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (Math.Abs(list[j] - i) <= k)
                        {
                            return true;
                        }
                    }
                    list.Add(i);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    dic.Add(nums[i], list);
                }
            }
            return false;

        }

        // method 1-官方题解1
        // 哈希表，但思路和“我的题解0”不太一样，官方的哈希表记录的是该数组元素的最大索引
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public bool ContainsNearbyDuplicate_1(int[] nums, int k)
        {
            // <数组元素, 该数组元素的最大索引> 
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (dic.ContainsKey(num) && i - dic[num] <= k)
                {
                    return true;
                }
                dic[num] = i;
            }
            return false;

        }

        // method 2-官方题解2
        // 滑动窗口
        // 时间复杂度：O(N)，空间复杂度：O(k)
        public bool ContainsNearbyDuplicate_2(int[] nums, int k)
        {
            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // 滑动窗口大小为k+1
                if (i > k)
                {
                    // 为了保持滑动窗口大小，右移时需要去掉左端点
                    hashSet.Remove(nums[i - k - 1]);
                }
                if (!hashSet.Add(nums[i]))
                {
                    // 添加失败，说明在这个窗口中出现重复数
                    return true;
                }
            }
            return false;

        }





    }
}