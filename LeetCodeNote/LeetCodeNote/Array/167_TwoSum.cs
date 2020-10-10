namespace LeetCodeNote.Array
{
    /// <summary>
    /// 167. 两数之和 II - 输入有序数组
    /// https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/
    /// </summary>


    public class Solution_167
    {
        // method 0
        // 二分查找（有序数组的常见套路）
        public int[] TwoSum_0(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int val = target - numbers[i];
                int left = i + 1;
                int right = numbers.Length - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (numbers[mid] == val)
                    {
                        return new int[] { i + 1, mid + 1 };
                    }
                    else if (numbers[mid] < val)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return new int[] { -1, -1 };

        }

        // method 1
        // 双指针
        public int[] TwoSum_1(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right) // 应题意，left不可以等于right，就是说这俩指针不会重合
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    return new int[] {left + 1, right + 1};
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return new int[] { -1, -1 };

        }


    }
}