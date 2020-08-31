namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1550. 存在连续三个奇数的数组
    /// https://leetcode-cn.com/problems/three-consecutive-odds/
    /// </summary>

    public class Solution_1550
    {
        // method 0
        public bool ThreeConsecutiveOdds_0(int[] arr)
        {
            for (int i = 0; i <= arr.Length - 3; i++)
            {
                if ((arr[i] & 1) == 1 && (arr[i + 1] & 1) == 1 & (arr[i + 2] & 1) == 1)  // 
                {
                    return true;
                }
            }
            return false;

        }

    }


}