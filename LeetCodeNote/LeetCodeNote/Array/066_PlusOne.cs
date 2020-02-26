namespace LeetCodeNote.Array
{
    /// <summary>
    /// 66. 加一
    /// https://leetcode-cn.com/problems/plus-one/
    /// </summary>
    public class Solution_66
    {
        // method 0
        public int[] PlusOne(int[] digits)
        {
            int len = digits.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] %= 10;
                if (digits[i] != 0)
                {
                    return digits;
                }
            }
            int[] arr = new int[len + 1];
            arr[0] = 1;
            digits.CopyTo(arr, 1);
            return arr;
        }
    }
}