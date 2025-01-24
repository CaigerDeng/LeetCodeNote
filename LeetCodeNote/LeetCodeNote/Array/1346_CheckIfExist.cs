using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1346. 检查整数及其两倍数是否存在
    /// https://leetcode-cn.com/problems/check-if-n-and-its-double-exist/
    /// </summary>

    public class Solution_1346
    {
        // method 0 
        // 暴力法
        public bool CheckIfExist_0(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int a = arr[i];
                for (int j = 0; j < arr.Length; j++)
                {
                    int b = arr[j];
                    if (i != j && a * 2 == b)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        // method 1
        // 排序 + 双指针
        public bool CheckIfExist_1(int[] arr)
        {
            System.Array.Sort(arr);
            int len = arr.Length;
            // 如果x是正数
            int q = 0;
            for (int p = 0; p < arr.Length; p++)
            {
                // 如果排序后数组有负有正，则q可能不会前进
                while (q < len && arr[p] * 2 > arr[q])
                {
                    q++;
                }
                if (q < len && p != q && arr[p] * 2 == arr[q])
                {
                    return true;
                }
            }
            // 如果x是负数
            q = len - 1;
            for (int p = len - 1; p >= 0; p--)
            {
                while (q >= 0 && arr[p] * 2 > arr[q])
                {
                    q--;
                }
                if (q >= 0 && p != q && arr[p] * 2 == arr[q])
                {
                    return true;
                }
            }
            return false;

        }

        // method 2
        // 词典
        public bool CheckIfExist_2(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var k in arr)
            {
                if (!dic.ContainsKey(k))
                {
                    dic.Add(k, 0);
                }
                dic[k]++;
            }
            foreach (var k in arr)
            {
                if (k != 0 && dic.ContainsKey(2 * k) && dic[2 * k] >= 1)
                {
                    return true;
                }
                if (k == 0 && dic.ContainsKey(2 * k) && dic[2 * k] >= 2)
                {
                    return true;
                }
            }
            return false;

        }











    }
}