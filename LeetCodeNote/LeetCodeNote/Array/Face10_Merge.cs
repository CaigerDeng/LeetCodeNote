namespace LeetCodeNote.Array
{

    /// <summary>
    /// 面试题 10.01. 合并排序的数组
    /// https://leetcode-cn.com/problems/sorted-merge-lcci/
    /// </summary>


    public class Solution_Face10_01
    {
        // method 0
        public void Merge_0(int[] A, int m, int[] B, int n)
        {
            for (int i = 0; i < n; i++)
            {
                A[m + i] = B[i];
            }
            System.Array.Sort(A);

        }

        // method 1
        public void Merge_1(int[] A, int m, int[] B, int n)
        {
            int a = 0;
            int b = 0;
            int i = 0;
            int[] arr = new int[m + n];
            while (a < m || b < n)
            {
                if (a == m)
                {
                    arr[i++] = B[b++];
                }
                else if (b == n)
                {
                    arr[i++] = A[a++];
                }
                else if(A[a] < B[b])
                {
                    arr[i++] = A[a++];
                }
                else
                {
                    arr[i++] = B[b++];
                }              
            }
            arr.CopyTo(A, 0);

        }

        // method 2
        public void Merge_2(int[] A, int m, int[] B, int n)
        {
            int a = m - 1;
            int b = n - 1;
            int tail = m + n -1;
            while (a >= 0 || b >= 0)
            {
                if (a == -1)
                {
                    A[tail--] = B[b--];
                }
                else if (b == -1)
                {
                    A[tail--] = A[a--];
                }
                else if (A[a] > B[b])
                {
                    A[tail--] = A[a--];
                }
                else
                {
                    A[tail--] = B[b--];
                }
            }

        }



    }

}