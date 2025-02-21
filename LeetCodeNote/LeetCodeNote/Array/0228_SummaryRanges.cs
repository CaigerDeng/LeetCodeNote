using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 228. 汇总区间
    /// https://leetcode.cn/problems/summary-ranges/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// （就是找连续的数字，例如Case1:[0,1,2,4,5,7] 012是连续的，所以用0-2区间表示，但是题目中2后面跟的是4，不是3，所以就要重新起一个新的区间了。
    /// 4后面是5，5后面不是6而是7，所以第二个区间是4-5。最后剩个7，那他自己就是个单独的区间了）
    /// </summary>
    public class Solution_228
    {

        public void Run()
        {

        }

        // (2025/2/20) method My 0-我的题解0
        // （没写出来，没看懂题目在问什么）
        // 时间复杂度：O(?)，空间复杂度：O(?)
        public IList<string> SummaryRanges_My_0(int[] nums)
        {
            return null;

        }

        // method 1-官方题解1
        // 一次遍历，当遇到相邻元素之间的差值大于1，就找到了一个区间。
        // 时间复杂度：O(N)，空间复杂度：O(1)
        public IList<string> SummaryRanges_1(int[] nums)
        {
            List<string> resList = new List<string>();
            int i = 0;
            int n = nums.Length;
            while (i < n)
            {
                int low = i;
                i++;
                while (i < n && nums[i] == nums[i - 1] + 1)
                {
                    i++;
                }
                int high = i - 1;
                StringBuilder sb = new StringBuilder(nums[low].ToString());
                if (low < high)
                {
                    sb.Append("->");
                    sb.Append(nums[high].ToString());
                }
                resList.Add(sb.ToString());
            }
            return resList;

        }



    }



}
