using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 283. 移动零
    /// https://leetcode-cn.com/problems/move-zeroes/
    /// </summary>

    public class Solution_283
    {
        // method 0
        // 官方题解的优化
        // ...不符题意
        public void MoveZeroes_0(int[] nums)
        {
            int numZero = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val == 0)
                {
                    numZero += 1;
                }
                else
                {
                    list.Add(val);
                }
            }
            for (int i = 0; i < numZero; i++)
            {
                list.Add(0);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = list[i];
            }
        }

        // method 1  
        // 双指针     
        public void MoveZeroes_1(int[] nums)
        {
            // q是最后一个非0数所在索引
            int q = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[q++] = nums[i];
                }
            }
            for (int i = q; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        // method 2   
        // 对 method 1 的优化  
        public void MoveZeroes_2(int[] nums)
        {
            // q是最后一个非0数所在索引
            for (int i = 0, q = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[q];
                    nums[q] = nums[i];
                    nums[i] = temp;
                    q++;
                }
            }
        }









    }
}