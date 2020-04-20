namespace LeetCodeNote.Array
{
    /// <summary>
    /// 905. 按奇偶排序数组
    /// https://leetcode-cn.com/problems/sort-array-by-parity/
    /// </summary>

    public class Solution_905
    {
        // method 0
        public int[] SortArrayByParity_0(int[] A)
        {
            System.Array.Sort(A, (a, b) => (a % 2).CompareTo(b % 2));
            return A;
        }

        // method 1
        // 把官方题解基础两个for循环整合成了一个
        public int[] SortArrayByParity_1(int[] A)
        {
            int[] res = new int[A.Length];
            int begin = 0;
            int end = A.Length - 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    res[begin++] = A[i];
                }
                else
                {
                    res[end--] = A[i];
                }
            }
            return res;
        }

        // method 2
        public int[] SortArrayByParity_2(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                if (A[i] % 2 > A[j] % 2)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
                if (A[i] % 2 == 0)
                {
                    i++;
                }
                if (A[j] % 2 == 1)
                {
                    j--;
                }
            }
            return A;
        }









    }
}