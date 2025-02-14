using System;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 953. 验证外星语词典
    /// https://leetcode-cn.com/problems/verifying-an-alien-dictionary/
    /// </summary>


    public class Solution_953_IsAlienSorted
    {
        // method 0
        public bool IsAlienSorted_0(string[] words, string order)
        {
            int[] arr = new int[26];
            for (int i = 0; i < order.Length - 1; i++)
            {
                arr[order[i] - 'a'] = i;
            }
            for (int i = 0; i < words.Length; i++)
            {
                bool flag = false; // 是否通过比较
                for (int j = 0; j < Math.Min(words[i].Length, words[i + 1].Length); j++)
                {
                    if (arr[words[i][j] - 'a'] == arr[words[i + 1][j] - 'a'])
                    {
                        continue;
                    }
                    else if (arr[words[i][j] - 'a'] > arr[words[i + 1][j] - 'a'])
                    {
                        return false;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag && words[i].Length > words[i + 1].Length)
                {
                    return false;
                }
            }
            return true;

        }

    }


}