namespace LeetCodeNote.Array
{
    /// <summary>
    /// 717. 1比特与2比特字符
    /// https://leetcode-cn.com/problems/1-bit-and-2-bit-characters/
    /// </summary>

    public class Solution_717
    {
        // 题目解释：0用1比特表示，10或11用两比特表示，肯定以0结尾。问末尾的0是属于1比特还是2比特表示？
        // method 0
        public bool IsOneBitCharacter_0(int[] bits)
        {
            int i = 0;
            while (i < bits.Length - 1)
            {
                i += bits[i] + 1;
            }
            return i == bits.Length - 1;
        }


        // method 1
        public bool IsOneBitCharacter_1(int[] bits)
        {
            // 开始i为最后的索引即 i = bits.Length - 1
            // 需要去掉最后一个0，则 i = bits.Length - 1 - 1
            // 即 i = bits.Length - 2
            int i = bits.Length - 2;
            while (i >= 0 && bits[i] > 0)
            {
                // 结束循环时，i会多减一次
                i--;
            }
            // 连续1的个数为 (bits.Length - 2) - i + 1 + 1
            // 即 bits.Length - i
            return (bits.Length - i) % 2 == 0;
        }







    }

}