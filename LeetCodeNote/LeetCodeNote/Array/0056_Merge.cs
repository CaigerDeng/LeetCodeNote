using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 56. 合并区间
    /// https://leetcode.cn/problems/merge-intervals/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_56
    {

        public void Run()
        {
            int[][] intervals = new[]
            {
                new int[] { 1,3},
                new int[] { 2, 6 },
                new int[] { 8,10 },
                new int[] { 15,18 },

            };

            int[][] res = Merge_My_0(intervals);
            foreach (int[] arr in res)
            {
                Console.Write("[{0}, {1}], ", arr[0], arr[1]);
            }


        }

        // (2025/2/20) method My 0-我的题解0
        // 用哈希表来记录区间的左右边界。
        // 失败！我的写法没法处理像[[1,4],[5,6]]这种情况（看似连续，但却是两个明确边界）
        // 时间复杂度：O(N)，空间复杂度：O(N)
        public int[][] Merge_My_0(int[][] intervals)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] arr = intervals[i];
                int a = arr[0];
                int b = arr[1];
                if (a == b)
                {
                    // 0 代表特别区间[x, x]
                    dic.TryAdd(a, 0);
                }
                else
                {
                    for (int j = a; j <= b; j++)
                    {
                        // 即使出现特别区间[x, x]，这里也会被覆盖掉
                        dic[j] = 1;
                    }
                }
            }

            // 构成数组用，大小不会超过2
            List<int> list = new List<int>();
            List<int[]> tempResList = new List<int[]>();

            foreach (KeyValuePair<int, int> kv in dic.OrderBy(kv => kv.Key))
            {
                // 如果还能出现0，说明肯定是单独的特别区间
                if (kv.Value == 0)
                {
                    list.Clear();
                    MakeArr(kv.Key, kv.Key, tempResList);
                }
                else
                {
                    if (list.Count <= 1)
                    {
                        list.Add(kv.Key);
                    }
                    else
                    {
                        // 只有大于和等于的情况，不可能会有小于的情况（因为已经排序）
                        if (kv.Key == list[1] + 1)
                        {
                            list[1] = kv.Key;
                        }
                        else if (kv.Key > list[1] + 1)
                        {
                            MakeArr(list[0], list[1], tempResList);
                            list.Clear();
                            list.Add(kv.Key);
                        }
                    }
                }
            }
            // 要么为2，要么为0
            if (list.Count == 2)
            {
                MakeArr(list[0], list[1], tempResList);
                list.Clear();
            }
            int[][] res = tempResList.ToArray();
            return res;

        }

        private void MakeArr(int a, int b, List<int[]> tempResList)
        {
            int[] arr = new int[2];
            arr[0] = a;
            arr[1] = b;
            tempResList.Add(arr);

        }


        // method 1-官方题解1
        // 排序。排序后，对区间的左右边界进行判断，要么更新要么直接添加.
        // （我之前想过排序，但我想如果出现一个区间范围特大把其他区间都包含，那排序没意义，看来官方解答了我的问题）
        // 时间复杂度：O(nlogn)，空间复杂度：O(logn)
        public int[][] Merge_1(int[][] intervals)
        {
            System.Array.Sort(intervals, (int[] a, int[] b) =>
            {
                return a[0] - b[0];
            });
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int left = intervals[i][0];
                int right = intervals[i][1];
                if (list.Count == 0 || list[^1][1] < left)
                {
                    list.Add(new int[] { left, right });
                }
                else
                {
                    list[^1][1] = Math.Max(list[^1][1], right);
                }
            }
            return list.ToArray();

        }



    }



}
