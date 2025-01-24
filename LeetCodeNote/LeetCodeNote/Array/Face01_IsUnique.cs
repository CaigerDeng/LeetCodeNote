namespace LeetCodeNote.Array
{
    /// <summary>
    /// 面试题 01.01. 判定字符是否唯一
    /// https://leetcode-cn.com/problems/is-unique-lcci/
    /// </summary>


    public class Solution_Face01_01
    {
        // method 0
        // 位运算
        // https://leetcode-cn.com/problems/is-unique-lcci/solution/wei-yun-suan-fang-fa-si-lu-jie-shao-by-zhen-zhu-ha/
        public bool IsUnique_0(string astr)
        {
            int mark = 0;
            foreach (char c in astr)
            {
                int distance = c - 'a';
                int val = 1 << distance;
                if ((mark & val) != 0)
                {
                    return false;
                }
                else
                {
                    mark |= val;
                }
            }
            return true;

        }

        // method 1
        // C#现成方法
        // https://leetcode-cn.com/problems/is-unique-lcci/solution/zhi-xing-yong-shi-72-ms-zai-suo-you-c-ti-jiao-zh-3/
        public bool IsUnique_1(string astr)
        {
            foreach (char c in astr)
            {
                int startIndex = astr.IndexOf(c);
                int endIndex = astr.LastIndexOf(c);
                if (startIndex != endIndex)
                {
                    return false;
                }
            }
            return true;

        }

        // method 2
        // 两个for循环
        public bool IsUnique_2(string astr)
        {
            for (int i = 0; i < astr.Length; i++)
            {
                for (int j = i + 1; j < astr.Length; j++)
                {
                    if (astr[i] == astr[j])
                    {
                        return false;
                    }
                }
            }
            return true;

        }


    }
}