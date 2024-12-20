using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    public class TestMisc
    {
        public void Run()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

            // 反转数组索引 2 开始的 4 个元素
            System.Array.Reverse(nums, 2, 4);

            // 输出结果
            Console.WriteLine(string.Join(", ", nums));







        }

       
       


    }




}
