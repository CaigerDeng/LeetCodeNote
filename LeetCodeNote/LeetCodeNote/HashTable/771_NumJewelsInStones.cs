using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 771. 宝石与石头
    /// https://leetcode-cn.com/problems/jewels-and-stones/
    /// </summary>

    public class Solution_771_NumJewelsInStones
    {
        // method 0
        // 暴力法
        public int NumJewelsInStones_0(string jewels, string stones)
        {
            int jewelsCount = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                char stone = stones[i];
                for (int j = 0; j < jewels.Length; j++)
                {
                    char jewel = jewels[j];
                    if (stone == jewel)
                    {
                        jewelsCount++;
                    }
                }
            }
            return jewelsCount;

        }

        // method 1
        // 哈希
        public int NumJewelsInStones_1(string jewels, string stones)
        {
            int jewelsCount = 0;
            HashSet<int> hs = new HashSet<int>();
            foreach (char jewel in jewels)
            {
                hs.Add(jewel);
            }
            foreach (char stone in stones)
            {
                if (hs.Contains(stone))
                {
                    jewelsCount++;
                }
            }          
            return jewelsCount;

        }


    }

}