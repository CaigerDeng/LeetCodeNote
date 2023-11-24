// deng：2023-11-20-我的想法是准备一个大小一样的数组，把nums中所有数当成索引，并计数；针对nums大小为1有特殊处理
// 但如果有出现次数相同的两个数，这算不算正常的测试用例呢？

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LeetCodeNote.Array
{
    /// <summary>
    /// 169. 多数元素
    /// https://leetcode.cn/problems/majority-element/
    /// </summary>

    public class Solution_169
    {

        public void Run()
        {
            int[] nums = new[] { 3, 2, 3 };
            int res = MajorityElement_4(nums);

            Print(res);



        }

        public void Print(int res)
        {
            Console.WriteLine(res);
        }

        // method 0
        // 使用哈希映射，时间复杂度O(n)，空间复杂度O(n)
        public int MajorityElement_0(int[] nums)
        {
            // 如果nums大小为1的特殊处理，主要是为了节省内存
            if (nums.Length == 1)
            {
                return nums[0];
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int majority = 0;
            int countMaj = 0;
            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
                if (dic[num] > countMaj)
                {
                    majority = num;
                    countMaj = dic[num];
                }
            }
            // 因为题目保证了一定会有多数元素，所以没有判断countMaj是否大于n/2
            return majority;

        }


        // method 0
        // 排序，因为多数元素的定义是出现次数大于n/2，这代表排序后的nums中至少有一半的数都是它，则nums中间那个数一定是多数元素
        // 时间复杂度O(nlogn)，空间复杂度O(logn)
        public int MajorityElement_1(int[] nums)
        {
            // 如果nums大小为1的特殊处理，主要是为了节省内存
            if (nums.Length == 1)
            {
                return nums[0];
            }
            System.Array.Sort(nums);
            return nums[nums.Length / 2];

        }

        // method 2 
        // 随机化
        public int MajorityElement_2(int[] nums)
        {
            // deng【？？？】:对于本解法的时间复杂度，高数期望有待补习
            int countMaj = nums.Length / 2;
            Random rnd = new Random();
            while (true)
            {
                int candidate = nums[rnd.Next(nums.Length)];
                int count = 0;
                foreach (var num in nums)
                {
                    if (num == candidate)
                    {
                        count++;
                        if (count > countMaj)
                        {
                            return num;
                        }
                    }
                }
            }
            return -1;

        }

        // method 3
        // 分治法，感觉和method 1意思一样，感觉没啥写的必要...
        public int MajorityElement_3(int[] nums)
        {
            // ...
            return -1;

        }

        // method 4
        // Boyer-Moore 投票算法
        // 时间复杂度O(n)，空间复杂度O(1)
        public int MajorityElement_4(int[] nums)
        {
            int count = 0;
            int candidate = -1;
            foreach (var num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                // 因为多数元素的定义（至少占数组元素一半），能确定count最后一定大于0，也就说明candidate在遍历后能记下真正的多数元素
                count += (num == candidate) ? 1 : -1;
            }
            return candidate;

        }


    }

}
