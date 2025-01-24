namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1170. 比较字符串最小字母出现频次
    /// https://leetcode-cn.com/problems/compare-strings-by-frequency-of-the-smallest-character/
    /// </summary>

    public class Solution_1170
    {
        // method 0
        public int[] NumSmallerByFrequency_0(string[] queries, string[] words)
        {
            int[] res = new int[queries.Length];
            int[] arr = new int[words.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = f(words[i]);
            }
            System.Array.Sort(arr);
            for (int i = 0; i < queries.Length; i++)
            {
                int num = f(queries[i]);
                res[i] = Search(num, arr);
            }
            return res;
        }

        private int Search(int num, int[] arr)
        {
            // 二分法变种
            // 查找第一个大于num的值
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] > num)
                {                   
                    if (mid == 0 || arr[mid - 1] <= num)
                    {
                        return arr.Length - mid;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left = mid + 1;
                }
            }
            return 0;
        }

        private int f(string str)
        {
            int count = 0;
            char minChar = 'z';
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < minChar)
                {
                    minChar = str[i];
                    count = 0;
                }
                if (str[i] == minChar)
                {
                    count++;
                }
            }
            return count;
        }


    }
}