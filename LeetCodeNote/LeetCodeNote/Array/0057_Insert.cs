using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 57. 插入区间
    /// https://leetcode.cn/problems/insert-interval/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_57
    {

        public void Run()
        {
            //int[][] intervals = new[]
            //{
            //    new []{1,3},
            //    new []{6,9},

            //};
            //int[] newInterval = new[] { 2, 5 }; // res:[[1,5],[6,9]]


            //int[][] intervals = new[]
            //{
            //    new []{1,2},
            //    new []{3,5},
            //    new []{6,7},
            //    new []{8,10},
            //    new []{12,16},

            //};
            //int[] newInterval = new[] { 4, 8 }; // res:[[1,2],[3,10],[12,16]]

            //int[][] intervals = new[]
            //{
            //    new []{1,5},

            //};
            //int[] newInterval = new[] { 2, 3 }; // res:[[1,5]]


            int[][] intervals = new[]
            {
                new []{1,5},

            };
            int[] newInterval = new[] { 6, 8 }; // res:[[1,5],[6,8]]




            int[][] res = Insert_My_0(intervals, newInterval);
            foreach (int[] arr in res)
            {
                Console.Write("[{0},{1}], ", arr[0], arr[1]);

            }


        }

        // (2025/2/21) method My 0-我的题解0
        // 先二分查找到合适插入位置，再分别向左、向右检测合并区间，最后对这俩方向的结果再检测。
        // 时间复杂度：O(logN)，空间复杂度：O(1)
        public int[][] Insert_My_0(int[][] intervals, int[] newInterval)
        {
            List<int[]> resList = new List<int[]>();
            if (intervals.Length == 0)
            {
                resList.Add(newInterval);
                return resList.ToArray();
            }
            // 1. 二分查找，找到第一个大于等于newInterval[0]的索引
            // insertIndex初始值必须为intervals.Length，因为如果整个intervals的区间都比newInterval小的话，那就是末尾插入。
            int insertIndex = intervals.Length;
            int left = 0;
            int right = intervals.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (intervals[mid][0] >= newInterval[0])
                {
                    insertIndex = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            // 2. 向左检测合并区间
            // 如果向左检测把左边区间全部走完，那leftStopIndex会为0，那么leftStopIndex初始值不能填0
            int leftStopIndex = -1;
            int[] leftArr = new int[2];
            System.Array.Copy(newInterval, leftArr, 2);
            for (int i = insertIndex - 1; i >= 0; i--)
            {
                int[] arr = intervals[i];
                if (arr[1] < leftArr[0])
                {
                    // 如果不重叠
                    leftStopIndex = i;
                    break;
                }
                else
                {
                    int a = Math.Min(leftArr[0], arr[0]);
                    int b = Math.Max(leftArr[1], arr[1]);
                    leftArr[0] = a;
                    leftArr[1] = b;
                }
            }
            if (leftStopIndex > -1)
            {
                for (int i = 0; i <= leftStopIndex; i++)
                {
                    resList.Add(intervals[i]);
                }
            }

            // 3. 向右检测合并区间
            int rightStopIndex = -1;
            int[] rightArr = new int[2];
            System.Array.Copy(newInterval, rightArr, 2);
            for (int i = insertIndex; i < intervals.Length; i++)
            {
                int[] arr = intervals[i];
                if (rightArr[1] < arr[0])
                {
                    // 如果不重叠
                    rightStopIndex = i;
                    break;
                }
                else
                {
                    int a = Math.Min(rightArr[0], arr[0]);
                    int b = Math.Max(rightArr[1], arr[1]);
                    rightArr[0] = a;
                    rightArr[1] = b;
                }
            }
            // 4. 左、右检测结果是否要合并
            if (leftArr[1] < rightArr[0])
            {
                // 如果不重叠
                resList.Add(leftArr);
                resList.Add(rightArr);
            }
            else
            {
                int a = Math.Min(leftArr[0], rightArr[0]);
                int b = Math.Max(leftArr[1], rightArr[1]);
                int[] arr = new int[2];
                arr[0] = a;
                arr[1] = b;
                resList.Add(arr);
            }
            if (rightStopIndex > -1)
            {
                for (int i = rightStopIndex; i < intervals.Length; i++)
                {
                    resList.Add(intervals[i]);
                }
            }

            return resList.ToArray();

        }

        // method 1-官方题解1
        // 模拟。官方思路和“我的题解0”差不多，但官方没用二分查找（因为没必要），官方的遍历更简洁明了
        // 时间复杂度：O(N)，空间复杂度：O(1)
        public int[][] Insert_1(int[][] intervals, int[] newInterval)
        {
            int left = newInterval[0];
            int right = newInterval[1];
            bool placed = false;
            List<int[]> resList = new List<int[]>();
            foreach (int[] interval in intervals)
            {
                if (interval[0] > right)
                {
                    // 在插入区间的右侧且无交集
                    if (!placed)
                    {
                        // 一定只会插入一次，因为intervals有序
                        resList.Add(new[] { left, right });
                        placed = true;
                    }
                    resList.Add(interval);
                }
                else if (interval[1] < left)
                {
                    // 在插入区间的左侧且无交集
                    resList.Add(interval);
                }
                else
                {
                    // 与插入区间有交集，计算它们的并集
                    left = Math.Min(left, interval[0]);
                    right = Math.Max(right, interval[1]);
                }
            }
            if (!placed)
            {
                resList.Add(new[] { left, right });
                placed = true;
            }
            return resList.ToArray();

        }





    }


}
