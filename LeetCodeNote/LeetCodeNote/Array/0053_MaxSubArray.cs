using System;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 53. 最大子序和
    /// https://leetcode-cn.com/problems/maximum-subarray/
    /// </summary>


    public class Solution_53
    {

        // method 0
        // ...动态规划
        public int MaxSubArray_0(int[] nums)
        {
            int pre = 0;
            int max = nums[0];
            foreach (int x in nums)
            {
                pre = Math.Max(pre + x, x);
                max = Math.Max(max, pre);
            }
            return max;

        }

        // method 1
        // 线段树
        public int MaxSubArray_1(int[] nums)
        {
            return GetInfo(nums, 0, nums.Length - 1).mSum;

        }

        public class Status
        {
            public int lSum; // 表示 [l,r] 内以 l 为左端点的最大子段和
            public int rSum; // 表示 [l,r] 内以 r为右端点的最大子段和
            public int mSum; // 表示 [l,r] 内的最大子段和
            public int iSum; // 表示 [l,r] 的区间和

            public Status(int lSum_, int rSum_, int mSum_, int iSum_)
            {
                lSum = lSum_;
                rSum = rSum_;
                mSum = mSum_;
                iSum = iSum_;
            }

        }

        public Status PushUp(Status l, Status r)
        {
            int iSum = l.iSum + r.iSum;
            int lSum = Math.Max(l.lSum, l.iSum + r.lSum);
            int rSum = Math.Max(r.rSum, r.iSum + l.rSum);
            int mSum = Math.Max(Math.Max(l.mSum, r.mSum), l.rSum + r.lSum);
            return new Status(lSum, rSum, mSum, iSum);

        }

        public Status GetInfo(int[] a, int l, int r)
        {
            if (l == r)
            {
                return new Status(a[l], a[l], a[l], a[l]);
            }
            int m = (l + r) >> 1;
            Status staL = GetInfo(a, l, m);
            Status staR = GetInfo(a, m + 1, r);
            return PushUp(staL, staR);

        }




    }

}