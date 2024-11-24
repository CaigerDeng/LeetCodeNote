using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 914. 卡牌分组
    /// https://leetcode-cn.com/problems/x-of-a-kind-in-a-deck-of-cards/
    /// </summary>

    public class Solution_914
    {
        // method 0
        public bool HasGroupsSizeX_0(int[] deck)
        {
            int N = deck.Length;
            int[] arr = new int[10000];
            for (int i = 0; i < deck.Length; i++)
            {
                int val = deck[i];
                arr[val]++;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                if (val > 0)
                {
                    list.Add(val);
                }
            }
            for (int X = 2; X <= N; X++)
            {
                if (N % X == 0)
                {
                    bool flag = true;
                    for (int i = 0; i < list.Count; i++)
                    {
                        int val = list[i];
                        if (val % X != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // method 1
        // 优化了method 0的后半部分
        public bool HasGroupsSizeX_1(int[] deck)
        {
            int[] arr = new int[10000];
            for (int i = 0; i < deck.Length; i++)
            {
                int val = deck[i];
                arr[val]++;
            }
            int g = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                if (val > 0)
                {
                    if (g == -1)
                    {
                        g = val;
                    }
                    else
                    {
                        g = gcd(g, val);
                    }
                }
            }
            return g >= 2;
        }

        public int gcd(int x, int y)
        {
            return x == 0 ? y : gcd(y % x, x);
        }



    }



}