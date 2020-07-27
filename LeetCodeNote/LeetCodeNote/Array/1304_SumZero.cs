namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1304. 和为零的N个唯一整数
    /// https://leetcode-cn.com/problems/find-n-unique-integers-sum-up-to-zero/
    /// </summary>

    public class Solution_1304
    {
        // method 0     
        // 我想到的是以从1开始，同时准备对应负数，如-2，-1，1，2，如果数不够就补0
        // 官方给的题解是从0开始，给出前n-1个数，第n个数为前n-1个数的和的负数   
        public int[] SumZero_0(int n)
        {
            int[] res = new int[n];
            int sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                res[i] = i;
                sum += i;
            }
            res[n - 1] = -sum;
            return res;

        }

    }
}