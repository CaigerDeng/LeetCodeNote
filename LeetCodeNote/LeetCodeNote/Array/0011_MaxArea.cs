using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 11. 盛最多水的容器
    /// https://leetcode.cn/problems/container-with-most-water/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_11
    {
        public void Run()
        {
            int[] height = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };



            int res = MaxArea_My_0(height);



            Console.WriteLine("res:{0}", res);

        }

        // 我的题解0，顺着题意双指针，没有别的优化点
        // 失败！超出时限
        public int MaxArea_My_0(int[] height)
        {
            // 写成元组只是为了看那两条线的数据
            (int, int, int) areaMax = (0, 0, 0);
            // 双指针都从头部开始
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int w = j - i;
                    int h = Math.Min(height[i], height[j]);
                    int area = w * h;
                    if (area > areaMax.Item1)
                    {
                        areaMax.Item1 = area;
                        areaMax.Item2 = i;
                        areaMax.Item3 = j;
                    }
                }
            }
            return areaMax.Item1;

        }

        // method 1 
        // 双指针，但和“我的题解0”不同的是，这里是头尾各放一个指针
        public int MaxArea_1(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int areaMax = 0;
            while (left < right) // 根据题意，他需要两条线来构成容器，因此left不可能等于right
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                areaMax = Math.Max(area, areaMax);
                // 移动值更小的那个指针，这样才能形成有效容器
                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return areaMax;

        }



    }

}
