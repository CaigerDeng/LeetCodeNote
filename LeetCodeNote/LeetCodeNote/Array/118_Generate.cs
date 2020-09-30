using System.Collections.Generic;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 118. 杨辉三角
    /// https://leetcode-cn.com/problems/pascals-triangle/
    /// </summary>
    public class Solution_118
    {
        // method 0 
        public IList<IList<int>> Generate_0(int numRows)
        {
            List<IList<int>> triangle = new List<IList<int>>();
            if (numRows <= 0)
            {
                return triangle;
            }
            // 第一行
            List<int> firstRow = new List<int>();
            firstRow.Add(1);
            triangle.Add(firstRow);
            for (int i = 1; i < numRows; i++)
            {
                List<int> preRow = (List<int>)triangle[i - 1];
                List<int> row = new List<int>();
                row.Add(1);
                for (int j = 1; j < i; j++)
                {
                    row.Add(preRow[j - 1] + preRow[j]);
                }
                row.Add(1);
                triangle.Add(row);
            }
            return triangle;
            
        }

      

    }
}