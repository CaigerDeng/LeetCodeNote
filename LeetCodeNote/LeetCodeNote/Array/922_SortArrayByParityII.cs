namespace LeetCodeNote.Array
{
    /// <summary>
    /// 922. 按奇偶排序数组 II
    /// https://leetcode-cn.com/problems/sort-array-by-parity-ii/
    /// </summary>

    public class Solution_922
    {
        // method 0
        public int[] SortArrayByParityII_0(int[] A)
        {
            int N = A.Length;
            int[] res = new int[N];
            int t = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] % 2 == 0)
                {
                    res[t] = A[i];
                    t += 2;
                }
            }
            t = 1;
            for (int i = 0; i < N; i++)
            {
                if (A[i] % 2 == 1)
                {
                    res[t] = A[i];
                    t += 2;
                }
            }
            return res;
        }

        // method 1
        public int[] SortArrayByParityII_1(int[] A)
        {
            int j = 1; // j从奇数索引开始
            for (int i = 0; i < A.Length; i += 2)
            {
                if (A[i] % 2 == 1) // 本应是偶数，但现在遇到奇数
                {
                    while (A[j] % 2 == 1) // j会在遇到A[j]为偶数时终止
                    {
                        j += 2;
                    }
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            return A;
        }






    }
}