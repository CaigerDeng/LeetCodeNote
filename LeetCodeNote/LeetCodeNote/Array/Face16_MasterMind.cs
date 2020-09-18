using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 16.15. 珠玑妙算
    /// https://leetcode-cn.com/problems/master-mind-lcci/
    /// </summary>


    public class Solution_Face16_15
    {
        // https://leetcode-cn.com/problems/master-mind-lcci/solution/fen-kai-lai-ji-by-shetia/
        // method 0
        public int[] MasterMind_0(string solution, string guess)
        {
            int allTimes = 0;
            int rightTimes = 0;
            List<char> list = guess.ToList();
            for (int i = 0; i < solution.Length; i++)
            {
                // 计算全猜对次数
                char c = solution[i];
                if (c == guess[i])
                {
                    rightTimes++;
                }
                // 计算猜中总次数
                int index = list.IndexOf(c);
                if (index != -1)
                {
                    allTimes++;
                    list.RemoveAt(index);
                }
            }
            int[] res = new[] { rightTimes, allTimes - rightTimes };
            return res;

        }

        // method 1
        public int[] MasterMind_1(string solution, string guess)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('R', 0);
            dic.Add('G', 0);
            dic.Add('B', 0);
            dic.Add('Y', 0);
            int fakeTimes = 0;
            int rightTimes = 0;
            for (int i = 0; i < solution.Length; i++)
            {
                char s = solution[i];
                char g = guess[i];
                if (s == g)
                {
                    rightTimes++;
                }
                else
                {
                    // s以正数形式记录在dic中
                    // g以负数形式记录在dic中
                    // 当用s去查找dic中，发现value仍有负数时，则伪猜中一次
                    // 当用g去查找dic中，发现value仍有正数时，则伪猜中一次
                    if (dic[s]++ < 0)
                    {
                        fakeTimes++;
                    }
                    if (dic[g]-- > 0)
                    {
                        fakeTimes++;
                    }
                }
            }
            int[] res = new[] { rightTimes, fakeTimes };
            return res;

        }



    }


}