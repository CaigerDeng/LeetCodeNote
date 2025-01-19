namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1486. 数组异或操作
    /// https://leetcode-cn.com/problems/xor-operation-in-an-array/
    /// </summary>


    public class Solution_1486
    {
        // method 0
        public int XorOperation_0(int n, int start)
        {
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                res ^= start + i * 2;
            }
            return res;

        }


    }
}