namespace LeetCodeNote.TwoPointers
{
    /// <summary>
    /// 28. 实现 strStr()
    /// https://leetcode-cn.com/problems/implement-strstr/
    /// </summary>


    public class Solution_28_StrStr
    {
        // method 0
        // 暴力BF
        public int StrStr_0(string haystack, string needle)
        {
            // 考虑haystack = needle，i + needle.Length <= haystack.Length 可以写等于号
            for (int i = 0; i + needle.Length <= haystack.Length; i++)
            {
                bool flag = true;
                for (var j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        flag = false;
                        break;
                    }                   
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;

        }

        // method 1
        // KMP
        public int StrStr_1(string haystack, string needle)
        {
           

            return -1;

        }


    }

}