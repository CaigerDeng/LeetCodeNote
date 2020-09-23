namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 17.10. 主要元素
    /// https://leetcode-cn.com/problems/find-majority-element-lcci/
    /// </summary>

    public class Solution_Face17_10
    {
        // method 0
        // 摩尔投票法，时间复杂度O(n)，空间复杂度O(1)
        // https://leetcode-cn.com/problems/find-majority-element-lcci/solution/zhu-yao-yuan-su-by-jiao-jiao-bai-ju/
        public int MajorityElement_0(int[] nums)
        {
            int major = 0;
            int times = 0;
            foreach (int x in nums)
            {
                if (times == 0)
                {
                    major = x;
                    times++;
                }
                else
                {
                    if (major == x)
                    {
                        times++;
                    }
                    else
                    {
                        times--;
                    }
                }
            }
            if (times > 0)
            {
                int t = 0;
                foreach (int x in nums)
                {
                    if (major == x)
                    {
                        t++;
                    }
                }
                if (t > nums.Length / 2)
                {
                    return major;
                }
            }
            return -1;

        }


    }



}