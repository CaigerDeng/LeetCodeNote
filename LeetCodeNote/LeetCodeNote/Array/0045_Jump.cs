using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 45. 跳跃游戏II
    /// https://leetcode.cn/problems/jump-game-ii/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>


    public class Solution_45
    {
        public void Run()
        {
            int[] nums = { 2, 3, 1, 1, 4 };


            int times = Jump_1(nums);
            Console.WriteLine("times:" + times);

        }


        // 我的题解0，在55. 跳跃游戏的method 1基础上修改的
        // 错误写法！
        public int Jump_My_0(int[] nums)
        {
            // 我认为每次一拓宽rightMost，其实就是一次跳跃，我只需求拓宽总次数就行，但这样是不对的，因为最少跳法包含在里面没有被提出来，看得出来我放弃思考了……
            int minTimes = 0;
            int rightMost = 0;
            int n = nums.Length;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i <= rightMost)
                {
                    int newRightMost = i + nums[i];
                    if (newRightMost > rightMost)
                    {
                        rightMost = newRightMost;
                        minTimes++;
                        
                    }
                    if (rightMost >= n - 1)
                    {
                        break;
                    }
                }
            }
            return minTimes;

        }

        // method 1 官方题解1
        // 可能会超时，官方不推荐
        // 从后往前跳，先找出能跳到最后一步的位置A，接着找能跳到位置A的位置B，以此类推。
        public int Jump_1(int[] nums)
        {
            int index = nums.Length - 1;
            int step = 0;
            while (index > 0) // 因为是从后往前找，index会越找越小，所以要保证index > 0
            {
                for (int i = 0; i < index; i++) // 贪心是体现在遍历是从左往右遍历，即希望越在前面的能跳得越最远
                {
                    if (i + nums[i] >= index)
                    {
                        step++;
                        index = i; // 已找到符合要求的位置，在它的基础上继续往前找
                        break;
                    }
                }
            }
            return step;

        }

        // method 2 官方题解2
        // 正向查找，记录边界
        // 有一点Jump_My_0的设计思想
        public int Jump_2(int[] nums)
        {
            int n = nums.Length;
            int end = 0; // 边界index，即当前索引最远能跳到哪个索引
            int maxIndex = 0;
            int step = 0;
            for (int i = 0; i < n - 1; i++) // 不用算上最后一个索引
            {
                // 随着遍历，maxIndex会变大，这时候不一定走到了上次记录的边界
                maxIndex = Math.Max(maxIndex, i + nums[i]);
                if (i == end) // 走到边界，更新边界
                {
                    
                    end = maxIndex;
                    step++;
                }
            }
            return step;

        }

    }
}
