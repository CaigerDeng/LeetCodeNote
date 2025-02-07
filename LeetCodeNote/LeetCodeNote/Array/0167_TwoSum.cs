using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 167. 两数之和 II - 输入有序数组
    /// https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/
    /// </summary>
    public class Solution_167
    {
        public void Run()
        {
            //int[] numbers = new[] { 2, 7, 11, 15 };
            //int target = 9;

            int[] numbers = new[] { 4, 15, 24, 28, 32, 34, 38, 52, 56, 60, 63, 65, 79, 108, 123, 139, 147, 149, 150, 152, 161, 175, 178, 182, 187, 188, 194, 203, 212, 217, 227, 229, 230, 231, 240, 243, 251, 255, 258, 265, 268, 272, 289, 295, 301, 304, 307, 316, 329, 335, 349, 351, 356, 359, 370, 370, 373, 377, 387, 388, 400, 405, 409, 415, 425, 430, 440, 441, 447, 449, 459, 470, 471, 484, 493, 494, 508, 509, 510, 523, 527, 529, 533, 542, 547, 555, 566, 570, 619, 620, 627, 636, 643, 645, 648, 650, 657, 659, 669, 677, 685, 689, 699, 704, 710, 721, 727, 736, 740, 745, 766, 771, 773, 781, 795, 805, 817, 843, 849, 851, 860, 873, 899, 907, 950, 955, 959, 965, 968, 977, 988, 989 };
            int target = 718;


            int[] res = TwoSum_My_0(numbers, target);



            Console.WriteLine("res:{0}, {1}", res[0], res[1]);

        }

        // 我的题解0，双指针，但第二个指针用了二分法（因为有序）来缩小查找范围
        public int[] TwoSum_My_0(int[] numbers, int target)
        {
            int[] res = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                int t = target - numbers[i];
                int start = i + 1;
                int end = numbers.Length - 1;
                // 先前我竟然用了for循环来写二分查找，这样的问题是有时候索引一旦加加就会越界，这样可能会漏算边界
                while (start <= end)
                {
                    int mid = (end - start) / 2 + start;
                    if (t < numbers[mid])
                    {
                        end = mid - 1;
                    }
                    else if (t == numbers[mid])
                    {
                        res[0] = i + 1;
                        res[1] = mid + 1;
                        return res;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return res;

        }


        // method 1 官方题解1
        // 和“我的题解0”一模一样
        // 时间复杂度：O(nlogn)，空间复杂度：O(1)
        public int[] TwoSum_1(int[] numbers, int target)
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

        // method 2
        // 双指针，这里的双指针是头部、尾部各放一个，大家向中间走
        public int[] TwoSum_2(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right) // 应题意，left不可能等于right，就是说这俩指针不会重合
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
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