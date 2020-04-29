using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 989. 数组形式的整数加法
    /// https://leetcode-cn.com/problems/add-to-array-form-of-integer/
    /// </summary>

    public class Solution_989
    {
        // method 0
        public IList<int> AddToArrayForm_0(int[] A, int K)
        {
            int N = A.Length;
            int cur = K;
            List<int> res = new List<int>();
            int i = N - 1;
            // 可能cur都除完了i还没有走完，所以需要加入i >= 0的循环条件
            while (i >= 0 || cur > 0)
            {
                if (i >= 0)
                {
                    cur += A[i];
                    i--;
                }
                res.Add(cur % 10);
                cur /= 10;

            }
            res.Reverse();
            return res;
        }

    }


}