using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    public class TestMisc
    {
        public void Run()
        {
            string[] words = { "abc", "def", "ghi" };
            foreach (var substring in GetConcatenatedSubstrings(words))
            {
                Console.WriteLine(substring);
            }


            //Console.WriteLine("res :{0}", bound);

        }

        public void Reverse(StringBuilder sb, int left, int right)
        {
            while (left < right) // 当left==right时，反转无意义，所以可以不写等于
            {
                (sb[left], sb[right]) = (sb[right], sb[left]);
                left++;
                right--;
            }

        }

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
        // 闭区间
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

        private int LowerBound(int[] a, int l, int r, int target)
        {
            int mid = -1, originL = l, originR = r;
            while (l < r)
            {
                mid = (l + r) >> 1;
                if (a[mid] < target) l = mid + 1;
                else r = mid;
            }

            return (a[l] >= target) ? l : -1;
        }

        static IEnumerable<string> GetConcatenatedSubstrings(string[] words)
        {
            Queue<(string, HashSet<int>)> queue = new Queue<(string, HashSet<int>)>();
            queue.Enqueue(("", new HashSet<int>()));  // 初始空字符串和空索引集合

            while (queue.Count > 0)
            {
                var (current, used) = queue.Dequeue();
                if (used.Count == words.Length)
                {
                    yield return current;
                    continue;
                }

                for (int i = 0; i < words.Length; i++)
                {
                    if (!used.Contains(i))
                    {
                        var newUsed = new HashSet<int>(used) { i };
                        queue.Enqueue((current + words[i], newUsed));
                    }
                }
            }
        }



    }




}
