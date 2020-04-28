namespace LeetCodeNote.Array
{
    /// <summary>
    /// 985. 查询后的偶数和
    /// https://leetcode-cn.com/problems/sum-of-even-numbers-after-queries/
    /// </summary>

    public class Solution_985
    {
        // method 0
        // 重点是对偶数和进行优化
        public int[] SumEvenAfterQueries_0(int[] A, int[][] queries)
        {
            int S = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    S += A[i];
                }
            }
            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int val = queries[i][0];
                int index = queries[i][1];
                if (A[index] % 2 == 0)
                {
                    S -= A[index];
                }
                A[index] += val;
                if (A[index] % 2 == 0)
                {
                    S += A[index];
                }
                ans[i] = S;
            }
            return ans;

        }



    }





}