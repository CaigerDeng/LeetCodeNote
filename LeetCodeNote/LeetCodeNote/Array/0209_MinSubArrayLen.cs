using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 209. 长度最小的子数组
    /// https://leetcode.cn/problems/minimum-size-subarray-sum/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_209
    {

        public void Run()
        {
            int[] nums = new[] { 2, 3, 1, 2, 4, 3 };
            int target = 7;

            //int[] nums = new[] { 1, 4, 4 };
            //int target = 4;

            //int[] nums = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            //int target = 11;

            //int[] nums = new[] { 1, 2, 3, 4, 5 };
            //int target = 11;

            int res = MinSubArrayLen_2_1(target, nums);
            Console.WriteLine("res:{0}", res);


        }

        // (2025/2/8) method My 0-我的题解0
        // 暴力查找，想写成滑动窗口但还是写成暴力查找了...
        // 时间复杂度：O(N*N)，空间复杂度：O(1)
        public int MinSubArrayLen_My_0(int target, int[] nums)
        {
            int sum = 0;
            int n = nums.Length;
            int a = 0;
            int b = 0;
            int lenMin = n + 1;
            while (a <= n - 1 && b <= n - 1)
            {
                if (b <= n - 1)
                {
                    sum += nums[b];
                }
                if (sum >= target)
                {
                    int len = b - a + 1;
                    lenMin = Math.Min(len, lenMin);
                    a++;
                    b = a;
                    sum = 0;
                }
                else
                {
                    if (a == 0 && b == n - 1)
                    {
                        // 总和都比target小，就不用再算
                        break;
                    }
                    b++;
                }
            }
            return lenMin != n + 1 ? lenMin : 0;

        }

        // method 1-官方题解1
        // 暴力查找，思路和“我的题解0”一样，但写的比“我的题解0”好多了
        // 超出时限！虽然程序没问题。
        // 时间复杂度：O(N*N)，空间复杂度：O(1)
        public int MinSubArrayLen_1(int target, int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum += nums[j];
                    if (sum >= target)
                    {
                        res = Math.Min(res, j - i + 1);
                        break;
                    }
                }
            }
            return res == int.MaxValue ? 0 : res;

        }

        // method 2_0-官方题解2
        // 前缀和+二分查找（使用现成API）
        // 时间复杂度：O(N*logN)，空间复杂度：O(N)
        public int MinSubArrayLen_2_0(int target, int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = int.MaxValue;
            // 前缀和
            // sums[0] = 0，代表前0个元素的前缀和为0
            // sums[1] = nums[0]，代表前1个元素的前缀和为nums[0]
            // sums[n]，代表前n个（即从nums[0]到nums[n-1]）元素的前缀和
            int[] sums = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                sums[i] = sums[i - 1] + nums[i - 1];
            }
            for (int i = 1; i <= n; i++)
            {
                int t = target + sums[i - 1];
                // 这里用了现成API - BinarySearch（实现细节可参考下面的LowerBound_0()或LowerBound_1()方法）
                // BinarySearch()的第3个参数是指有效长度
                // 这意味着sum[bound]比sum[i - 1]起码要多target
                int bound = System.Array.BinarySearch(sums, i, sums.Length - i, t);
                if (bound < 0)
                {
                    bound = ~bound;
                }
                // bound = 0，代表目标应该插在第0位（即头部），即整个前缀和数组的所有元素都比目标小
                // bound=sums.Length，代表目标应该插在前缀和数组尾部，即nums的总和都比target小，再算下去无意义
                if (bound < sums.Length)
                {
                    res = Math.Min(res, bound - i + 1);
                }
            }
            return res == int.MaxValue ? 0 : res;

        }

        // 求在数组arr中，第一个大于等于target的值的索引
        // left和right都是取有效值
        // 不熟悉的写法，我觉得不是很好理解...
        private int LowerBound_0(int[] arr, int left, int right, int target)
        {
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    // 不能漏掉mid，所以写成right = mid，而不是写成right = mid-1;
                    right = mid;
                }
            }
            // 这里做了判断，如果arr的所有元素都比target小，返回-1，代表无意义（仅仅针对本题，本题认为不越界的left才是有意义的left）。
            // 一般API会直接返回left。
            return (arr[left] >= target) ? left : -1;

        }

        // 求在数组arr中，第一个大于等于target的值的索引
        // 这是我熟悉的写法
        private int LowerBound_1(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            int index = arr.Length;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] >= target)
                {
                    index = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return index;

        }

        // method 2_1-官方题解2
        // 前缀和+二分查找（不使用现成API）
        // 时间复杂度：O(N*logN)，空间复杂度：O(N)
        public int MinSubArrayLen_2_1(int target, int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = int.MaxValue;
            // 前缀和
            // sums[0] = 0，代表前0个元素的前缀和为0
            // sums[1] = nums[0]，代表前1个元素的前缀和为nums[0]
            // sums[n]，代表前n个（即从nums[0]到nums[n-1]）元素的前缀和
            int[] sums = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                sums[i] = sums[i - 1] + nums[i - 1];
            }
            for (int i = 1; i <= n; i++)
            {
                int t = target + sums[i - 1];
                // 这里是不用现成API - BinarySearch的写法
                // 这意味着sum[bound]比sum[i - 1]起码要多target
                int bound = LowerBound_0(sums, i, n, t);
                if (bound != -1)
                {
                    res = Math.Min(res, bound - i + 1);
                }
            }
            return res == int.MaxValue ? 0 : res;

        }

        // method 3-官方题解3
        // 滑动窗口
        // 时间复杂度：O(N)，空间复杂度：O(1)
        public int MinSubArrayLen_3(int target, int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = int.MaxValue;
            int start = 0;
            int end = 0;
            int sum = 0;
            while (end < n)
            {
                sum += nums[end];
                while (sum >= target)
                {
                    res = Math.Min(res, end - start + 1);
                    sum-= nums[start];
                    start++;
                }
                end++;
            }
            return res == int.MaxValue ? 0 : res;

        }



    }

}
