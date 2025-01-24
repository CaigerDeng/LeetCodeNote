// deng：2023-11-19-这题重点想考我啥？看上去很像动态规划方面的题。——> 有点动态规划的意思。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LeetCodeNote.Array
{
    /// <summary>
    /// 15. 三数之和
    /// https://leetcode.cn/problems/3sum/description/
    /// </summary>

    public class Solution_15
    {

        public void Run()
        {
            //int[] nums = new[] { -1, 0, 1, 2, -1, -4 };
            //int[] nums = new[] { 0, 0, 0 };
            //int[] nums = new[] { 1, -1, -1, 0 };
            //int[] nums = new[] { 0, 1, 1 };
            //int[] nums = new[] { 3, 0, -2, -1, 1, 2 };
            //int[] nums = new[] { 1, 2, -2, -1 };
            int[] nums = new[] { 3, -2, 1, 0 };

            IList<IList<int>> res = ThreeSum_1(nums);
            Print(res);



        }

        public void Print(IList<IList<int>> list)
        {
            Console.WriteLine("Count:" + list.Count);
            foreach (var item in list)
            {
                foreach (var val in item)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }

        }

        // method 0
        // 先排序，再三重循环，缺点是超时限
        // 为什么要排序？我觉得三重循环里的索引值已经限定了顺序，不可能出现b、a、c这种顺序啊？
        // ——> 因为题目要求“答案中不可以包含重复的三元组”，在示例1中nums = [-1,0,1,2,-1,-4]，有一个输出是[-1,0,1]，但是nums里其实有两个-1，虽然二者索引不同，但都输出都答案就重复了，不符题意。排序能保证-1们都呆一块。
        public IList<IList<int>> ThreeSum_0(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            // 特别处理
            if (nums.Length == 3)
            {
                int sum = 0;
                foreach (var val in nums)
                {
                    sum += val;
                }
                if (sum == 0)
                {
                    List<int> list = new List<int>();
                    foreach (var val in nums)
                    {
                        list.Add(val);
                    }
                    res.Add(list);
                }
                return res;
            }

            // 备份
            int target = 0;
            int[] arr = new int[nums.Length];
            System.Array.Copy(nums, arr, nums.Length);
            // 排序，为了符合题目要求
            System.Array.Sort(arr);

            // 三重循环
            //first < arr.Length - 3 ，应题目要求，保证有3个数
            for (int first = 0; first <= arr.Length - 3; first++)
            {
                // 后半部分判断我原先写的都是arr[first] != arr[first + 1]，但这样不对，因为这样写就会有跳过情况，
                // 比如nums=[-1,-1,0,1,2],就会跳过第一个-1,只会得到一个三元组（[-1,0,1]）,但其实应有两个三元组（[-1,-1,2]和[-1,0,1]）
                // 改成arr[first] != arr[first - 1]就不会跳过第一个数
                // first == 0是考虑此时三元组的第一个数还未填上，同时保证arr[first - 1]正常
                if (first == 0 || arr[first] != arr[first - 1])
                {
                    // second < arr.Length - 2，应题目要求，保证有3个数
                    for (int second = first + 1; second <= arr.Length - 2; second++)
                    {
                        // second == first + 1是考虑此时三元组的第二个数还未填上
                        if (second == first + 1 || arr[second] != arr[second - 1])
                        {
                            for (int third = second + 1; third < arr.Length; third++)
                            {
                                if (third == second + 1 || arr[third] != arr[third - 1])
                                {
                                    if (arr[first] + arr[second] + arr[third] == target)
                                    {
                                        List<int> list = new List<int>();
                                        list.Add(arr[first]);
                                        list.Add(arr[second]);
                                        list.Add(arr[third]);
                                        res.Add(list);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res;

        }

        // method 1
        // 在method 0基础上，设计了双指针来优化循环，不过这里的双指针是针对三数之和为0而设计的，如果和不为0，代码应该不能硬套
        public IList<IList<int>> ThreeSum_1(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (nums.Length == 3)
            {
                int sum = 0;
                foreach (var val in nums)
                {
                    sum += val;
                }
                if (sum == 0)
                {
                    List<int> list = new List<int>();
                    foreach (var val in nums)
                    {
                        list.Add(val);
                    }
                    res.Add(list);
                }
                return res;
            }

            int target = 0;
            int[] arr = new int[nums.Length];
            System.Array.Copy(nums, arr, nums.Length);
            System.Array.Sort(arr);

            for (int first = 0; first <= arr.Length - 3; first++)
            {
                if (first == 0 || arr[first] != arr[first - 1])
                {
                    int third = arr.Length - 1;
                    for (int second = first + 1; second <= arr.Length - 2; second++)
                    {
                        if (second == first + 1 || arr[second] != arr[second - 1])
                        {
                            if (third <= second)
                            {
                                break;
                            }
                            while (third > second + 1 && arr[first] + arr[second] + arr[third] > 0)
                            {
                                // 往左移动
                                third--;
                            }
                            if (arr[first] + arr[second] + arr[third] == target)
                            {
                                List<int> list = new List<int>();
                                list.Add(arr[first]);
                                list.Add(arr[second]);
                                list.Add(arr[third]);
                                res.Add(list);
                            }
                        }
                    }
                }
            }
            return res;

        }



    }

}
