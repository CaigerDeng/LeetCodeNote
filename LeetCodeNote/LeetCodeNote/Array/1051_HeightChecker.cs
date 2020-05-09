namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1051. 高度检查器
    /// https://leetcode-cn.com/problems/height-checker/
    /// 题目中文翻译容易误解，另附上英文网址
    /// https://leetcode.com/problems/height-checker/
    /// </summary>

    public class Solution_1051
    {
        // method 0
        public int HeightChecker_0(int[] heights)
        {
            int[] arr = new int[101]; // 0-100，不过其实0是不需要的
            for (int i = 0; i < heights.Length; i++)
            {
                int num = heights[i];
                arr[num]++;
            }
            int count = 0;
            for (int i = 1, j = 0; i < arr.Length; i++)
            {
                while (arr[i]-- > 0)
                {
                    if (heights[j++] != i)
                    {
                        count++;
                    }
                }
            }
            return count;
        }


    }
}