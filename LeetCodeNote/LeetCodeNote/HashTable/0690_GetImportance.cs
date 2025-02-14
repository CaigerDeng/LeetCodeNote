using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 645. 错误的集合
    /// https://leetcode-cn.com/problems/set-mismatch/
    /// </summary>


    public class Solution_690_GetImportance
    {

        //Definition for Employee.
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }

        private Dictionary<int, Employee> dic;

        // method 0
        public int GetImportance(IList<Employee> employees, int id)
        {
            dic = new Dictionary<int, Employee>();
            foreach (Employee e in employees)
            {
                if (!dic.ContainsKey(e.id))
                {
                    dic.Add(e.id, e);
                }
            }
            return Dfs(id);

        }

        private int Dfs(int id)
        {
            Employee employee = dic[id];
            int res = employee.importance;
            foreach (int subId in employee.subordinates)
            {
                res += Dfs(subId);
            }            
            return res;

        }


    }

}