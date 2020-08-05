using System;

namespace LeetCodeNote.Array
{

    /// <summary>
    /// 1385. 两个数组间的距离值
    /// https://leetcode-cn.com/problems/find-the-distance-value-between-two-arrays/
    /// </summary>

    public class Solution_1385
    {
        // method 1
        // 暴力
        public int FindTheDistanceValue_0(int[] arr1, int[] arr2, int d)
        {
            int res = 0;
            foreach (var a in arr1)
            {
                bool isAllOk = true;
                foreach (var b in arr2)
                {
                    if (Math.Abs(a - b) <= d)
                    {
                        isAllOk = false;
                        break;
                    }
                }
                if (isAllOk)
                {
                    res++;
                }
            }
            return res;

        }

        // method 2
        // 二分查找
        public int FindTheDistanceValue_1(int[] arr1, int[] arr2, int d)
        {
            int res = 0;
            System.Array.Sort(arr2);
            foreach (var a in arr1)
            {
                int neiLeft = FindNeighbourLeft(arr2, a);
                int neiRight = FindNeighbourRight(arr2, a);
                if (neiLeft == -1 && Math.Abs(a - neiRight) > d)
                {
                    // 找不到比a更小的，说明a就是最小的
                    res++;
                    continue;
                }
                if (neiRight == -1 && Math.Abs(a - neiLeft) > d)
                {
                    // 找不到比a更大的，说明a就是最大的
                    res++;
                    continue;
                }
                if (Math.Abs(a - neiLeft) > d && Math.Abs(a - neiRight) > d)
                {
                    res++;
                }
            }
            return res;

        }

        public int FindNeighbourLeft(int[] arr, int k)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < k )
                {
                    if (mid == arr.Length - 1 ||  arr[mid + 1] >= k )
                    {
                        return arr[mid];
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    right = mid - 1;                   
                }
            }
            return -1;

        }

        public int FindNeighbourRight(int[] arr, int k)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] >= k)
                {
                    if (mid == 0 || arr[mid - 1] < k)
                    {
                        return arr[mid];
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;

        }







    }


}