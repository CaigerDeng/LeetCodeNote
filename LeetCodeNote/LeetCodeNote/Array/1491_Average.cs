using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1491. 去掉最低工资和最高工资后的工资平均值
    /// https://leetcode-cn.com/problems/average-salary-excluding-the-minimum-and-maximum-salary/
    /// </summary>


    public class Solution_1491
    {
        // method 0
        public double Average_0(int[] salary)
        {
            double min = salary.Min();
            double max = salary.Max();
            double sum = salary.Sum();
            double aver = (sum - min - max) / (salary.Length - 2);
            return aver;

        }

    }
}