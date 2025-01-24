namespace LeetCodeNote.Array
{
    /// <summary>
    /// 941. 有效的山脉数组
    /// https://leetcode-cn.com/problems/valid-mountain-array/
    /// </summary>

    public class Solution_941
    {

        // method 0 
        public bool ValidMountainArray_0(int[] A)
        {
            int N = A.Length;
            int i = 0;
            while (i + 1 < N && A[i] < A[i + 1])
            {
                i++;
            }
            if (i == 0 || i == N - 1)
            {
                return false;
            }
            while (i + 1 < N && A[i] > A[i + 1])
            {
                i++;
            }
            return i == N - 1;
        }


    }


}