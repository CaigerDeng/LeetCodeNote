namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1287. 有序数组中出现次数超过25%的元素
    /// https://leetcode-cn.com/problems/element-appearing-more-than-25-in-sorted-array/
    /// </summary>

    public class Solution_1284
    {
        // method 0
        public int FindSpecialInteger_0(int[] arr)
        {
            int times = 0;
            int val = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == val)
                {
                    times++;
                    if (times * 4 > arr.Length)
                    {
                        return val;
                    }
                }
                else
                {
                    val = arr[i];
                    times = 1;
                }
            }
            return -1;

        }



        // 以下俩题解都来自 https://leetcode-cn.com/problems/element-appearing-more-than-25-in-sorted-array/solution/javaer-fen-cha-zhao-by-alphacat-5/
        // method 1
        // 滑窗
        public int FindSpecialInteger_1(int[] arr)
        {
            int windowSize = arr.Length / 4;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[i + windowSize])
                {
                    return arr[i];
                }
            }
            return -1;
        }

        // method 2
        // 对method 1的优化
        // 对二分法扣了很多细节
        public int FindSpecialInteger_2(int[] arr)
        {
            // ...
            return -1;
        }


    }
}