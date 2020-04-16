using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 888. 公平的糖果交换
    /// https://leetcode-cn.com/problems/fair-candy-swap/
    /// </summary>

    public class Solution_888
    {
        // method 0 
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int sa = 0;
            int sb = 0;
            HashSet<int> hashB = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                sa += A[i];
            }
            for (int i = 0; i < B.Length; i++)
            {
                sb += B[i];
                hashB.Add(B[i]);
            }
            int delta = (sb - sa) / 2;
            int[] res = new int[2];
            for (int i = 0; i < A.Length; i++)
            {
                int x = A[i];
                int y = x + delta;
                if (hashB.Contains(y))
                {
                    res[0] = x;
                    res[1] = y;
                    break;
                }
            }
            return res;
        }



    }





}