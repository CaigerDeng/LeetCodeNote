namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1185. 一周中的第几天
    /// https://leetcode-cn.com/problems/day-of-the-week/
    /// </summary>

    public class Solution_1185
    {

        // method 0
        public string DayOfTheWeek_0(int day, int month, int year)
        {
            // 先查到1971年1月1日是周五
            // 因为要从周一开始数，周一 + 4 = 周五，所以sum要为4
            int sum = 4;
            if (year != 1971)
            {
                for (int i = 1971; i < year; i++)
                {
                    sum += GetDaysOfYear(i);
                }
            }
            // 此处有优先级
            string[] weekNames = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            // 每个月的天数
            int[] mDays = new int[12];
            mDays[0] = 31;
            mDays[1] = IsLeapYear(year) ? 29 : 28;
            mDays[2] = 31;
            mDays[3] = 30;
            mDays[4] = 31;
            mDays[5] = 30;
            mDays[6] = 31;
            mDays[7] = 31;
            mDays[8] = 30;
            mDays[9] = 31;
            mDays[10] = 30;
            mDays[11] = 31;

            for (int i = 0; i < month - 1; i++)
            {
                sum += mDays[i];
            }
            sum += day;
            return weekNames[sum % 7];
        }

        private int GetDaysOfYear(int year)
        {
            return IsLeapYear(year) ? 366 : 365;
        }

        private bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }

        // method 1
        // 蔡勒公式
        // https://zh.wikipedia.org/wiki/%E8%94%A1%E5%8B%92%E5%85%AC%E5%BC%8F


    }
}