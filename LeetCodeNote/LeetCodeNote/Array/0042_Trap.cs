using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 42. 接雨水
    /// https://leetcode.cn/problems/trapping-rain-water/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_42
    {

        public void Run()
        {
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            //int[] height = { 4, 2, 0, 3, 2, 5 };



            int res = Trap_My_0(height);
            Console.WriteLine("res:{0}", res);


        }

        // method 0 我的题解0
        // 没通过！超出时限！时间复杂度O(n*n)
        public int Trap_My_0(int[] height)
        {
            int res = 0;
            int n = height.Length;
            int maxHeight = height.Max();
            // 按每一个高度去找坑
            for (int h = 1; h <= maxHeight; h++)
            {
                int a = 0;
                int b = 0;
                for (int i = 0; i < n; i++)
                {
                    if (height[i] >= h)
                    {
                        b = i - 1;
                        if (b >= a && b >= 0 && a - 1 >= 0 && height[a - 1] >= h) // 要形成一个坑才能存雨水
                        {
                            res += b - a + 1;
                        }
                        a = i + 1; // 结算完a就往后挪
                    }
                }
            }
            return res;

        }

        // method 1 官方题解1
        // 动态规划，时间复杂度O(n)
        // 核心就是，某位置的雨水容量 = 某位置能容纳的高度（需要左右最高边界来确定）- 某位置柱子。
        // 对于官方给出的彩图解释：左上leftMax柱形图，单个元素值=深绿色+浅绿色；右上rightMax柱形图，单个元素值=深红色+粉红色。如果把这两个彩图重叠，会发现浅绿和粉红相互交错的地方就是雨水容量。
        public int Trap_1(int[] height)
        {
            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }
            int[] leftMax = new int[n]; // 对于每个height[i]的左边界最大值
            leftMax[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }

            int[] rightMax = new int[n]; // 对于每个height[i]的右边界最大值
            rightMax[^1] = height[^1];
            for (int i = n - 2; i >= 0; i--) // 注意这里要用倒序
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                // 该位置的雨水容量 = 能容纳的高度-该位置柱子
                res += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }
            return res;

        }


        // method 3 官方题解3
        // 是官方题解1的优化，把空间复杂度从O(n)降到O(1)
        public int Trap_3(int[] height)
        {
            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = 0;
            // 左右数组化为左右指针，左指针从左往右走，右指针从右往左走，相遇即结算完
            int left = 0;
            int right = n - 1;
            int leftMax = 0;
            int rightMax = 0;
            while (left < right)
            {
                leftMax = Math.Max(leftMax, height[left]);
                rightMax = Math.Max(rightMax, height[right]);
                if (height[left] < height[right])
                {
                    // 这时候height[left]更小，减height[left]其实只是在减柱子
                    res += leftMax - height[left];
                    left++;
                }
                else
                {
                    res += rightMax - height[right];
                    right--;
                }
            }
            return res;

        }

        // method 2 官方题解2
        // 单调栈，栈里存的是高度递减的索引们
        // 官方题解1是算该位置雨水的容量，官方题解2是算雨水范围长方形面积（从右往左扫描确定宽度，左右边界确定高度）（有“我的题解0”影子）
        public int Trap_2(int[] height)
        {
            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }
            int res = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && height[i] > height[stack.Peek()]) // 递减区间后突然递增，即正好形成一个坑
                {
                    int top = stack.Pop();
                    if (stack.Count <= 0)
                    {
                        break;
                    }
                    int left = stack.Peek();
                    int currWidth = i - left - 1; // 相当于从此位置往前找第一个新左边界来确定长方形的宽
                    int currHeight = Math.Min(height[i], height[left]) - height[top]; // 因为上一句代码已经确定长方形的宽，所以在这个宽的范围里找实际高度
                    // 这样算长方形竟然不会和前面有重合，有点厉害！
                    res += currWidth * currHeight;
                }
                stack.Push(i); // 这里能保证呈递减趋势添加到栈中
            }
            return res;

        }






    }

}
