namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1502. 判断能否形成等差数列
    /// https://leetcode-cn.com/problems/can-make-arithmetic-progression-from-sequence/
    /// </summary>

    public class Solution_1502
    {
        // method 0
        public bool CanMakeArithmeticProgression_0(int[] arr)
        {
            System.Array.Sort(arr);
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] * 2 != arr[i - 1] + arr[i + 1])
                {
                    return false;
                }
            }
            return true;

        }

    }
}