using System.Text;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 844. 比较含退格的字符串
    /// https://leetcode-cn.com/problems/backspace-string-compare/
    /// </summary>


    public class Solution_844
    {
        // 只是为了拿到字符串中的单个字符，就会占用额外空间，所以C#不可能有空间复杂度O(1)的解法

        // method 0
        public bool BackspaceCompare_0(string S, string T)
        {
            return Build(S) == Build(T);

        }

        private string Build(string str)
        {
            StringBuilder sb = new StringBuilder();
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                if (c != '#')
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
            }
            return sb.ToString();

        }

        // method 1
        public bool BackspaceCompare_1(string S, string T)
        {
            char[] arrS = S.ToCharArray();
            char[] arrT = T.ToCharArray();
            int i = arrS.Length - 1;
            int j = arrT.Length - 1;
            int skipS = 0;
            int skipT = 0;
            while (i >= 0 || j >= 0)
            {
                // 处理S
                while (i >= 0)
                {
                    if (arrS[i] == '#')
                    {
                        skipS++;
                        i--;
                    }
                    else if (skipS > 0)
                    {
                        skipS--;
                        i--;
                    }
                    else
                    {
                        // 没有可以删的
                        break;
                    }
                }
                // 处理T
                while (j >= 0)
                {
                    if (arrT[j] == '#')
                    {
                        skipT++;
                        j--;
                    }
                    else if (skipT > 0)
                    {
                        skipT--;
                        j--;
                    }
                    else
                    {
                        // 没有可以删的
                        break;
                    }
                }
                if (i >= 0 && j >= 0)
                {
                    if (arrS[i] != arrT[j])
                    {
                        return false;
                    }
                }
                else
                {
                    // 如果正常走完的话，i和j是负数
                    if (i >= 0 || j >= 0)
                    {
                        return false;
                    }
                }
                // 以下两句是为了上面服务的
                i--;
                j--;
            }
            // 以上都是判断不相等的情况，如果都通过的话，那就是相等了
            return true;

        }



    }

}