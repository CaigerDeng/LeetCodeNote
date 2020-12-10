using System;

namespace LeetCodeNote.Stack
{

    /// <summary>
    /// 1598. 文件夹操作日志搜集器
    /// https://leetcode-cn.com/problems/crawler-log-folder/
    /// </summary>

    public class Solution_1598
    {
        // method 0
        public int MinOperations_0(string[] logs)
        {
            int step = 0;
            for (int i = 0; i < logs.Length; i++)
            {
                string str = logs[i];
                if (str == "../")
                {
                    step--;
                    step = Math.Max(0, step);
                }
                else if(str == "./")
                {
                    
                }
                else
                {
                    step++;
                }
            }
            return step;

        }

    }
}