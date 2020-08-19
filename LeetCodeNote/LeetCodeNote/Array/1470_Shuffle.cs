namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1470. 重新排列数组
    /// https://leetcode-cn.com/problems/shuffle-the-array/
    /// </summary>

    public class Solution_1470
    {
        // method 0
        // 空间复杂度 O(n) 
        public int[] Shuffle_0(int[] nums, int n)
        {
            int[] res = new int[2 * n];
            for (int i = 0; i < n; i++)
            {
                res[2 * i] = nums[i];
                res[2 * i + 1] = nums[i + n];
            }
            return res;

        }

        // method 1
        // 因为题目要求元素肯定是正数，所以可使用负数标记，空间复杂度 O(1)，
        public int[] Shuffle_1(int[] nums, int n)
        {
            for (int i = 0; i < 2 * n; i++)
            {
                // 正数表示需要检测，一直检测直到它变成负数才检测完毕
                if (nums[i] > 0)
                {
                    int j = i;
                    while (nums[i] > 0)
                    {
                        // 注意这里是拿j来判断
                        j = j < n ? 2 * j : 2 * (j - n) + 1;
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        // 负数表示检测完毕
                        nums[j] *= -1;
                    }
                }
            }
            for (int i = 0; i < 2 * n; i++)
            {
                // 回到正数
                nums[i] *= -1;
            }
            return nums;

        }





    }

}