namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1450. 在既定时间做作业的学生人数
    /// https://leetcode-cn.com/problems/number-of-students-doing-homework-at-a-given-time/
    /// </summary>

    public class Solution_1450
    {
        // method 0
        public int BusyStudent_0(int[] startTime, int[] endTime, int queryTime)
        {
            int num = 0;
            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= queryTime && queryTime <= endTime[i] )
                {
                    num++;
                }
            }
            return num;

        }





    }


}