namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1010. 总持续时间可被 60 整除的歌曲
    /// https://leetcode-cn.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
    /// </summary>

    public class Solution_1010
    {
        // 以下题解来自 
        // https://leetcode-cn.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/solution/jian-duan-you-rong-yi-li-jie-de-on-suan-fa-by-ciel/

        // method 0
        public int NumPairsDivisibleBy60_0(int[] time)
        {
            int[] bucket = new int[60];
            for (int i = 0; i < time.Length; i++)
            {
                bucket[time[i] % 60]++;
            }
            int res = 0;
            for (int i = 0; i < 60; i++)
            {
                if (bucket[i] == 0)
                {
                    continue;
                }
                if (i == 0 || i == 30)
                {
                    res += bucket[i] * (bucket[i] - 1);
                }
                else
                {
                    res += bucket[i] * bucket[60 - i];
                }
            }
            return res / 2;
        }

        // method 1
        // 是对method 0的优化
        public int NumPairsDivisibleBy60_1(int[] time)
        {
            int[] bucket = new int[60];
            int res = 0;
            for (int i = 0; i < time.Length; i++)
            {
                int mod = time[i] % 60;
                int remain = mod == 0 ? 0 : 60 - mod;
                res += bucket[remain];
                bucket[mod]++;
            }
            return res;
        }


    }
}